# Process
### 1.Choose Architecture
- Monolithic Architecture
- Clean Architecture
	- Domain
	- Application
	- Presentation

### 2.Audit Fields With  Shadow Property
- Add Auditable attribute
- override OnModelCreating
- override  SaveChanges

### 3.Add Identity
- Add new DB context
- Rename Schema
- Add identity to endpoint