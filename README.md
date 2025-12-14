# University Management System (UMS)

## Overview
The **University Management System (UMS)** is a subsystem of the **Unified Citizen Information Access Portal (UCIAP)**. It manages student academic and administrative records and provides verified university-level data to UCIAP through secure APIs.

The system ensures that student information is shared only with authorized parties under strict authentication, authorization, and consent controls.

---

## Key Features
- Student academic record management
- Secure RESTful APIs for data access
- Role-based access control
- Integration with UCIAP for education data verification
- Audit-friendly data handling

---

## Technology Stack
### Backend
- .NET 8 (ASP.NET Core Web API)

### Frontend
- Angular

### Database
- PostgreSQL / SQL Server

### Security
- OAuth 2.0 / OpenID Connect
- JWT-based authentication
- Keycloak (via UCIAP)

---

## System Integration
- Functions as a **higher-education data provider** within the UCIAP ecosystem
- Communicates with UCIAP via secure REST APIs
- Does not expose data directly to external institutions
- All API requests are validated using Keycloak-issued JWT tokens

---

## Developer
- **Mathisa Malsan**

---

## Purpose
This project was developed for academic purposes to demonstrate:
- Secure academic data management
- API-driven system interoperability
- Modern authentication and authorization practices

---

## License
This project is intended for educational use only.
