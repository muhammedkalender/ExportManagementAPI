using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Authentication;
using ExportManagementAPI.Domain.Entities.Config;
using ExportManagementAPI.Domain.Entities.User;
using ExportManagementAPI.Domain.Entities.UserToken;
using ExportManagementAPI.Domain.Repositories;
using ExportManagementAPI.Domain.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExportManagementAPI.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtConfig _jwtConfig;

        private readonly IUserRepositoryAsync _userRepository;
        private readonly IUserTokenRepositoryAsync _userTokenRepository;

        private readonly IPasswordService _passwordService;

        public AuthenticationService(IOptions<JwtConfig> jwtConfig,
            IUserRepositoryAsync userRepository,
            IUserTokenRepositoryAsync userTokenRepository,
            IPasswordService passwordService
        )
        {
            _jwtConfig = jwtConfig.Value;
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _passwordService = passwordService;
        }

        public async Task<ResponseEntity<AuthenticateResponse>> AuthenticateAsync(
            AuthenticateRequest authenticateRequest,
            string ipAddress)
        {
            IList<ValidationFailure> errorMessages = new List<ValidationFailure>();

            var user = (await _userRepository.FindByCondition(e =>
                    (e.UserName.ToLower().Equals(authenticateRequest.UserName.ToLower()) ||
                     e.Email.ToLower().Equals(authenticateRequest.UserName.ToLower()))).ConfigureAwait(false))
                .AsQueryable()
                .FirstOrDefault();

            if (user == null)
            {
            }

            if (!_passwordService.IsBase64String(authenticateRequest.Password))
            {
                errorMessages.Add(new ValidationFailure("Password", $"Password is not base64 encoded."));
            }

            if (user != null)
            {
                var isPasswordValid = _passwordService.VerifyPasswordHash(authenticateRequest.Password,
                    Convert.FromBase64String(user.Password), Convert.FromBase64String(user.Password));

                if (!isPasswordValid)
                {
                    errorMessages.Add(new ValidationFailure("Password", $"Password is incorrect"));
                }
            }

            if (errorMessages.Count > 0)
            {
                throw new ValidationException(errorMessages);
            }

            var jwtSecurityToken = await GenerateJwtToken(user);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var userToken = GenerateRefreshToken(ipAddress);
            userToken.JwtToken = jwtToken;
            userToken.Id = user.Id;

            user.Tokens.Add(userToken);

            await _userRepository.UpdateAsync(Mapper.Map<UserEntity, UserUpdateRequestEntity>(user))
                .ConfigureAwait(false);

            AuthenticateResponse response = new AuthenticateResponse()
            {
                Id = user.Id.ToString(),
                Token = jwtToken,
                Email = user.Email,
                Status = user.Status.Type.ToString(),
                RefreshToken = userToken.Token,
                ActionTime = DateTime.UtcNow
            };

            return new ResponseEntity<AuthenticateResponse>(response);
        }

        public Task<ResponseEntity<ForgotPasswordResponse>> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseEntity<RefreshTokenResponse>> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseEntity<ResetPasswordResponse>> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseEntity<RevokeTokenResponse>> RevokeTokenAsync(RevokeTokenRequest revokeTokenRequest, string ipAddress)
        {
            throw new NotImplementedException();
        }

        private Task<JwtSecurityToken> GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtConfig.DurationInMinutes),
                signingCredentials: signingCredentials
            );

            return Task.FromResult(jwtSecurityToken);
        }

        private UserTokenEntity GenerateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];

                rngCryptoServiceProvider.GetBytes(randomBytes);

                return new UserTokenEntity()
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpireDate = DateTime.UtcNow,
                    InsertDate = DateTime.UtcNow,
                    InsertIp = ipAddress
                };
            }
        }
    }
}