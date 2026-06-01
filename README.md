<div align="center">

# 🎁 Değer Yolcuları

### Production-Grade Non-Profit Donation Platform

A full-stack web platform empowering a Turkish charity organization to manage fundraising campaigns, process secure online donations, and engage donors transparently.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-19.0-61DAFB?logo=react&logoColor=black)](https://react.dev/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5.x-3178C6?logo=typescript&logoColor=white)](https://www.typescriptlang.org/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

[**View Demo**](#) · [**Architecture**](ARCHITECTURE.md) · [**Security**](SECURITY.md) · [**Deployment**](DEPLOYMENT.md)

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