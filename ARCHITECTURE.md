# Name & Folding Standards

---

## Application

### Mappings
`Application/Mappings/{name}Mapping`

### Console Commands
`Application/Console/{category}/{name}ConsoleCommand`

### Mediatr Commands
`Application/Commands/{category}/{crud}`

### Mediatr Queries
`Application/Queries/{category}/{crud}`

### Services
`Application/Services/{name}Service`

---

## Domain

### Models
`Domain/Entities/{name}Entity`

### Enums
`Domain/Enums/{name}Enum`

### Exceptions
`Domain/Exceptions/{name}Exception`

### Requests ( DTOs )
`Domain/Requests/{name}Request`'

### Responses ( DTOs )
`Domain/Requests/{name}Response`'

### Wrappers
`Domain/Wrappers/{name}Wrapper`

### Service Interfaces
`Doamin/Services/I{name}`

### Repository Interfaces
`Domain/Repositories/{name}Repository`

---

## Web

### Controllers

`Web/Controllers/{name}Controller`

### Extension Configurations
`Web/Extensions/{name}Extension`

### Middlewares
`Web/Middlewares/{name}Middleware`

## Infrastructure

### Repositories
`Infrastructure/Repositories/{name}Repository`

### Context
`Infrastructure/Contexts/{name}Context`'

### Migrations
`Infrastructure/Migration/{name}Migrate`'

### Seeds
`Infrastructure/Seeds/{name}Seed`'

---

## Test

`{projectName}.{testType}/{~}Tests`