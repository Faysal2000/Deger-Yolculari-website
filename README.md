<div align="center">

# 🎁 Değer Yolcuları

### Production-Grade Non-Profit Donation Platform

A full-stack web platform empowering a Turkish charity organization to manage fundraising campaigns, process secure online donations, and engage donors transparently.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-19.0-61DAFB?logo=react&logoColor=black)](https://react.dev/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5.x-3178C6?logo=typescript&logoColor=white)](https://www.typescriptlang.org/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)


</div>

---

## 📖 Table of Contents

- [Overview](#-overview)
- [Key Features](#-key-features)
- [Screenshots](#-screenshots)
- [Tech Stack](#-tech-stack)
- [Architecture](#-architecture)
- [Local Setup](#-local-setup)
- [Project Structure](#-project-structure)
- [Highlights](#-technical-highlights)
- [Roadmap](#-roadmap)
- [Author](#-author)

---

## 🌟 Overview

**Değer Yolcuları** ("Value Travelers") is an end-to-end donation platform purpose-built for a Turkish non-profit organization. It enables donors — both registered and anonymous — to support fundraising campaigns through a secure, transparent, and user-friendly experience.

The platform was designed with **enterprise-grade architecture** and follows industry best practices for **maintainability, security, and scalability**. It serves two distinct audiences:

- **Public visitors** — donors, supporters, and beneficiaries — through a polished, mobile-first website
- **Administrative staff** — through a comprehensive dashboard for content and campaign management

---

## ✨ Key Features

### Public Platform
| Feature | Description |
|---------|-------------|
| 🎁 **Donation Campaigns** | Browse active fundraising campaigns with real-time progress tracking |
| 💳 **3D Secure Payments** | iyzico integration with bank-level OTP verification for every transaction |
| 🔓 **Anonymous Donations** | Donate without registration — maximum accessibility |
| 📜 **PDF Certificates** | Auto-generated personalized donation certificates |
| 📰 **Content Hub** | News, events, announcements, articles, and document libraries |
| 📊 **Live Statistics** | Real-time donor count, total raised, and campaign metrics |
| 📧 **Newsletter** | Email subscriptions with confirmation flow |
| 📱 **Mobile-First** | Fully responsive across all devices and screen sizes |

### Admin Dashboard
| Feature | Description |
|---------|-------------|
| 📈 **Analytics** | Monthly donations chart, top campaigns, recent activity |
| 📝 **Content CMS** | Full CRUD for news, events, articles, announcements, campaigns |
| 🎨 **Site Customization** | Editable hero, vision/mission, logo, beneficiary counts |
| 👥 **Subscribers** | Newsletter management with export capabilities |
| 📁 **File Manager** | Document uploads (PDF/Excel/Word/images) up to 100 MB |
| 🔐 **Password Recovery** | 6-digit code via email with rate limiting & attempt tracking |
| 📋 **Audit Trail** | Automatic logging of every administrative action |

---

## 📸 Screenshots

<table>
  <tr>
    <td align="center"><b>Homepage</b></td>
    <td align="center"><b>Campaign Detail</b></td>
  </tr>
  <tr>
    <td><img src="docs/screenshots/01-homepage.png" alt="Homepage" /></td>
    <td><img src="docs/screenshots/02-campaign.png" alt="Campaign Detail" /></td>
  </tr>
  <tr>
    <td align="center"><b>Donation Form</b></td>
    <td align="center"><b>3D Secure Verification</b></td>
  </tr>
  <tr>
    <td><img src="docs/screenshots/03-donation-form.png" alt="Donation Form" /></td>
    <td><img src="docs/screenshots/04-3ds.png" alt="3D Secure" /></td>
  </tr>
  <tr>
    <td align="center"><b>Admin Dashboard</b></td>
    <td align="center"><b>Mobile View</b></td>
  </tr>
  <tr>
    <td><img src="docs/screenshots/05-admin-dashboard.png" alt="Admin Dashboard" /></td>
    <td><img src="docs/screenshots/06-mobile.png" alt="Mobile View" /></td>
  </tr>
</table>

---

## 🛠️ Tech Stack

### Backend
- **ASP.NET Core 9** — Modern web API framework
- **Entity Framework Core 9** — ORM with Code-First migrations
- **SQL Server 2022** — Relational database
- **JWT + Custom Refresh Tokens** — Stateless authentication
- **PBKDF2** — Cryptographic password hashing
- **FluentValidation** — Declarative input validation
- **QuestPDF** — Dynamic PDF generation
- **SendGrid** — Transactional email delivery
- **iyzico SDK** — Payment processing with 3D Secure
- **Swagger / OpenAPI** — Interactive API documentation

### Frontend
- **React 19** — Modern UI framework
- **TypeScript 5** — Type-safe development
- **Vite** — Lightning-fast build tool
- **React Router DOM v6** — Declarative routing
- **TanStack Query** — Powerful server-state management
- **Axios** — HTTP client with interceptors and auto-refresh
- **React Hot Toast** — Notification system
- **Lucide React** — Icon library

---

## 🏗️ Architecture

The backend implements **Clean Architecture** with strict separation of concerns across four layers:



<img width="1158" height="1359" alt="Image" src="https://github.com/user-attachments/assets/15430206-67be-42eb-bea2-eaaa05d8e6d5" />





### Design Patterns Applied
- **Repository Pattern** with generic `IRepository<T>`
- **Unit of Work** for transactional consistency
- **Dependency Injection** throughout
- **DTO Pattern** for clean API contracts
- **Result Pattern** via `ApiResponse<T>`
- **Strategy Pattern** for swappable Mock/Production services

> 📐 For a detailed architectural overview, see [**ARCHITECTURE.md**](ARCHITECTURE.md)

---

## 🚀 Local Setup

### Prerequisites
- .NET 9 SDK
- Node.js 20+ and npm
- SQL Server 2022 (Express or higher)
- Visual Studio 2022/2026 or VS Code

### Backend

```bash
# Clone the repository
git clone https://github.com/yourusername/deger-yolculari.git
cd deger-yolculari

# Configure settings
cp src/deger-yolculari.API/appsettings.example.json src/deger-yolculari.API/appsettings.json
# Edit appsettings.json with your local values

# Apply database migrations
dotnet ef database update \
  --project src/deger-yolculari.Infrastructure \
  --startup-project src/deger-yolculari.API

# Run the API
dotnet run --project src/deger-yolculari.API
```

API runs on: `http://localhost:5252`
Swagger UI: `http://localhost:5252/swagger`

### Frontend

```bash
cd client
npm install
npm run dev
```

Frontend runs on: `http://localhost:5173`

---

## 📂 Project Structure


deger-yolculari/
├── src/
│   ├── deger-yolculari.API/              # Controllers, Middleware, Auth
│   ├── deger-yolculari.Application/      # DTOs, Interfaces, Validators
│   ├── deger-yolculari.Domain/           # Entities, Business Rules
│   └── deger-yolculari.Infrastructure/   # EF Core, Services, Repositories
│
├── client/
│   └── src/
│       ├── api/                          # Axios instance + API clients
│       ├── components/                   # Reusable UI components
│       ├── context/                      # React Context providers
│       ├── pages/
│       │   ├── public/                   # Public-facing pages
│       │   └── admin/                    # Admin dashboard pages
│       └── types/                        # TypeScript interfaces
│
└── docs/                                 # Documentation & assets
├── screenshots/
└── diagrams/




---

## 🎓 Technical Highlights

This project demonstrates proficiency in:

- ✅ **Clean Architecture** in a real-world .NET application
- ✅ **Production-grade authentication** without ASP.NET Identity
- ✅ **3rd-party payment gateway integration** with full 3DS support
- ✅ **PDF generation** with dynamic content and branding
- ✅ **Email service abstraction** with environment-aware implementations
- ✅ **EF Core migrations** for controlled schema evolution
- ✅ **TypeScript with React 19** following modern patterns
- ✅ **TanStack Query** for declarative server-state management
- ✅ **Mobile-first responsive design** with vanilla CSS
- ✅ **DevOps mindset** — dev/staging/production separation, env-based configs
- ✅ **Security best practices** — see [SECURITY.md](SECURITY.md) for details

---

## 🗺️ Roadmap

- [ ] Deploy staging environment on Azure App Service
- [ ] Integrate Azure Blob Storage for media files
- [ ] Add public gallery page
- [ ] Multi-language support (TR/EN/AR)
- [ ] Donation milestone notifications
- [ ] Monthly financial transparency reports
- [ ] Mobile apps (iOS/Android) using React Native

---

## 👤 Author

**Faysal Elbeg**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-0A66C2?logo=linkedin&logoColor=white)](https://linkedin.com/in/faysal-elbeg-715285223)
[![GitHub](https://img.shields.io/badge/GitHub-Follow-181717?logo=github&logoColor=white)](https://github.com/Faysal2000)
[![Email](https://img.shields.io/badge/Email-Contact-D14836?logo=gmail&logoColor=white)](mailto:faysalelbeg@gmail.com)
---

## 🙏 Acknowledgments

Built with care for the **Değer Yolcuları** non-profit organization, with the mission of making philanthropy more transparent and accessible across Turkey.

> *"Bilmekten Çok Yaşamak İçin"* — *"To Live, More Than Just to Know"*

---

<div align="center">

⭐ **If you found this project interesting, please consider giving it a star!**

</div>



<img width="1448" height="1086" alt="Image" src="https://github.com/user-attachments/assets/af6c3380-675f-4de3-a0ff-c6f1269d8b45" />





### Layer Responsibilities

#### 🎯 Domain Layer (Innermost)
**Location:** `src/deger-yolculari.Domain/`

**Contents:**
- Entities (`User`, `Donation`, `Campaign`, etc.)
- Value Objects
- Domain Events (future expansion)
- Business Rules

**Dependencies:** **None** — pure C# with no external references

**Example:**
```csharp
public class Donation : BaseEntity
{
    public Guid CampaignId { get; set; }
    public decimal Amount { get; set; }
    public DonationStatus Status { get; set; }
    // ... pure data + behavior
}
```

#### 🧠 Application Layer
**Location:** `src/deger-yolculari.Application/`

**Contents:**
- DTOs (Data Transfer Objects)
- Service Interfaces (`IAuthService`, `IDonationService`, etc.)
- Validators (FluentValidation)
- Application-specific logic

**Dependencies:** Domain only

#### ⚙️ Infrastructure Layer
**Location:** `src/deger-yolculari.Infrastructure/`

**Contents:**
- EF Core DbContext + Configurations
- Repository implementations
- Service implementations (`AuthService`, `DonationService`, `EmailService`)
- External integrations (iyzico, SendGrid)

**Dependencies:** Application + Domain

#### 🌐 API Layer (Outermost)
**Location:** `src/deger-yolculari.API/`

**Contents:**
- Controllers
- Middleware (Exception handling, CORS, Auth)
- Program.cs (Composition Root)
- Configuration files

**Dependencies:** Application + Infrastructure + Domain

---

## 🎨 Design Patterns

### 1. Repository Pattern
Abstracts data access behind generic interfaces, enabling easy testing and swapping of data sources.

```csharp
public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> Query();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
```

### 2. Unit of Work
Coordinates writing changes across multiple repositories in a single transaction.

```csharp
public interface IUnitOfWork
{
    IRepository<User> Users { get; }
    IRepository<Donation> Donations { get; }
    IRepository<Campaign> Campaigns { get; }
    Task<int> SaveChangesAsync();
}
```

### 3. Result Pattern
All service methods return a typed `ApiResponse<T>` for consistent error handling.

```csharp
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
    
    public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };
    public static ApiResponse<T> Fail(string message) => new() { Success = false, Message = message };
}
```

### 4. Strategy Pattern (Mock/Production)
Email and payment services have multiple implementations switched via configuration.

```csharp
// Registered in Program.cs based on appsettings:
if (config.GetValue<bool>("SendGrid:UseMock"))
    services.AddScoped<IEmailService, MockEmailService>();
else
    services.AddScoped<IEmailService, SendGridEmailService>();
```

### 5. Dependency Injection
ASP.NET Core's built-in DI container manages all service lifetimes.

```csharp
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IDonationService, DonationService>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
```

---

## 🗄️ Database Design

The system uses **13 normalized tables** managed through EF Core Code-First migrations.

### Entity Overview

| Table | Purpose | Key Relationships |
|-------|---------|-------------------|
| `Users` | Admin and registered user accounts | One-to-many with audit logs |
| `News`, `Events`, `Announcements`, `Articles` | Editorial content | Authored by Users (Admins) |
| `Gallery` | Multi-image support for events | Many-to-one with Events |
| `DonationCampaigns` | Fundraising campaign metadata | One-to-many with Donations |
| `Donations` | Transaction records | Many-to-one with Campaigns (User optional) |
| `Files` | Document library | Uploaded by Admins |
| `NewsletterSubscribers` | Email subscriptions | Independent |
| `AuditLogs` | Administrative action history | Many-to-one with Users |
| `SiteSettings` | Editable site-wide content | Singleton record |
| `PasswordResetCodes` | Hashed 6-digit codes | Many-to-one with Users |

### Key Design Decisions

#### 1. **Anonymous Donations Support**
The `Donations.UserId` field is **nullable**, with `DonorName` and `DonorEmail` capturing guest information. This maximizes accessibility — donors don't need accounts to contribute.

#### 2. **Soft Audit Trail**
The `AuditLogs` table records every administrative action, providing forensic capability without complicating primary tables.

#### 3. **Atomic Multi-Image Saves**
When creating events with multiple images, the Event entity and its Gallery rows are saved in a single `SaveChangesAsync()` call, ensuring transactional consistency.

#### 4. **Hashed Reset Codes**
Password reset codes are **never stored in plain text**. They're hashed with PBKDF2 before storage, with expiry timestamps and attempt counters for brute-force protection.

---

## 💳 Payment Flow Architecture

The platform integrates **iyzico** with full 3D Secure support across three environments.

### High-Level Flow




<img width="1402" height="1122" alt="Image" src="https://github.com/user-attachments/assets/8a5320a6-19d4-4663-a15a-619df03f43f8" />





### Multi-Environment Strategy

| Environment | Mode | Purpose |
|-------------|------|---------|
| **Development** | Mock | Local feature development; no external dependencies |
| **Staging** | iyzico Sandbox | Pre-production testing with real 3DS flow |
| **Production** | iyzico Live | Real money transactions |

A single configuration flag (`Iyzico:UseMock`) switches modes without code changes.

---

## 🔌 External Integrations

### iyzico (Payment Gateway)
- **Purpose:** Card payment processing with 3D Secure
- **Abstraction:** `IDonationService` with Mock and Sandbox implementations
- **Endpoints used:** `ThreedsInitialize.Create()`, `ThreedsPayment.Create()`

### SendGrid (Email Service)
- **Purpose:** Transactional emails (newsletter confirmations, password reset codes, donation receipts)
- **Abstraction:** `IEmailService` with Mock and SendGrid implementations
- **Templates:** HTML emails with organization branding

### QuestPDF (PDF Generation)
- **Purpose:** Donor certificate generation
- **Customization:** Editable thank-you message via SiteSettings
- **Output:** Branded PDF with logo, donor name, amount, date

---

## 🎯 Frontend Architecture

### State Management Strategy

| State Type | Tool | Use Case |
|------------|------|----------|
| Server State | TanStack React Query | API data, caching, refetching |
| Auth State | React Context | User session, JWT tokens |
| Form State | useState (local) | Form inputs |
| URL State | React Router | Navigation, query params |

### Component Organization


client/src/
├── api/              # API clients (axios instance + service modules)
├── components/
│   └── common/       # Shared UI components (Navbar, Footer, modals)
├── context/          # React Context providers
├── hooks/            # Custom React hooks
├── pages/
│   ├── public/       # Public-facing pages
│   └── admin/        # Admin dashboard pages
├── types/            # TypeScript interfaces
└── utils/            # Helper functions




### Routing Strategy

- **Public routes** — Wrapped in `<PublicLayout>` with Navbar/Footer
- **Auth routes** — Standalone layout (Login, ForgotPassword)
- **Admin routes** — Wrapped in `<AdminLayout>` with Sidebar/Topbar, protected by `<ProtectedRoute>`

---

## ⚡ Performance Considerations

### Backend
- **Async/Await throughout** — No blocking I/O
- **EF Core Query Optimization** — `.Include()` only when needed, `.AsNoTracking()` for reads
- **Pagination** — All list endpoints support page/pageSize
- **Connection Pooling** — Default EF Core pooling enabled

### Frontend
- **Code Splitting** — Route-based lazy loading
- **Query Caching** — TanStack Query with sensible stale times
- **Optimistic Updates** — Better perceived performance for admin actions
- **Image Optimization** — Properly sized assets, lazy loading

---

## 🔮 Future Architectural Evolution

As the platform grows, the following patterns may be introduced:

- **CQRS** — Separate read/write models for high-volume queries
- **MediatR** — Mediator pattern for cleaner request handling
- **Event Sourcing** — For comprehensive audit trail
- **Redis Caching** — For frequently accessed read-only data
- **Background Jobs** — Hangfire for scheduled tasks (newsletter sends, report generation)
- **Microservices** — If donation volume requires horizontal scaling
