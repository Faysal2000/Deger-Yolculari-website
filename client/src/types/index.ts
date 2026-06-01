// ─── Auth ────────────────────────────────────────────
export interface User {
  id: string;
  fullName: string;
  email: string;
  phoneNumber?: string;
  role: 'Admin' | 'User';
  createdAt: string;
}

export interface AuthResponse {
  accessToken: string;
  refreshToken: string;
  accessTokenExpiry: string;
  user: User;
}

export interface LoginDto {
  email: string;
  password: string;
}

export interface RegisterDto {
  fullName: string;
  email: string;
  password: string;
  phoneNumber?: string;
}

// ─── API Response ────────────────────────────────────
export interface ApiResponse<T> {
  success: boolean;
  message?: string;
  data?: T;
  errors?: string[];
}

export interface PagedResult<T> {
  items: T[];
  totalCount: number;
  page: number;
  pageSize: number;
  totalPages: number;
  hasNext: boolean;
  hasPrev: boolean;
}

export interface PaginationParams {
  page?: number;
  pageSize?: number;
  search?: string;
}

// ─── News ────────────────────────────────────────────
export interface News {
  id: string;
  title: string;
  content: string;
  imageUrl?: string;
  isPublished: boolean;
  publishedAt?: string;
  createdAt: string;
  adminName: string;
}

export interface CreateNewsDto {
  title: string;
  content: string;
  imageUrl?: string;
  isPublished: boolean;
}

export interface UpdateNewsDto {
  title: string;
  content: string;
  imageUrl?: string;
  isPublished: boolean;
}

// ─── Events ──────────────────────────────────────────
export interface Event {
  id: string;
  title: string;
  description: string;
  location?: string;
  eventDate: string;
  imageUrl?: string;
  imageUrls: string[];
  isPublished: boolean;
  createdAt: string;
  adminName: string;
}

export interface CreateEventDto {
  title: string;
  description: string;
  location?: string;
  eventDate: string;
  imageUrls: string[];
  isPublished: boolean;
}

// ─── Announcements ───────────────────────────────────
export interface Announcement {
  id: string;
  title: string;
  content: string;
  isActive: boolean;
  createdAt: string;
  adminName: string;
}

export interface CreateAnnouncementDto {
  title: string;
  content: string;
  isActive: boolean;
}

// ─── Articles ────────────────────────────────────────
export interface Article {
  id: string;
  title: string;
  content: string;
  imageUrl?: string;
  isPublished: boolean;
  publishedAt?: string;
  createdAt: string;
  adminName: string;
}

export interface CreateArticleDto {
  title: string;
  content: string;
  imageUrl?: string;
  isPublished: boolean;
}

// ─── Donations ───────────────────────────────────────
export interface CreateCampaignDto {
  title: string;
  description: string;
  imageUrl?: string;
  goalAmount: number;
  currency: string;
  isOpen: boolean;
  startDate: string;
  endDate?: string;
}

export interface DonationCampaign {
  id: string;
  title: string;
  description: string;
  imageUrl?: string;
  goalAmount: number;
  collectedAmount: number;
  progressPercentage: number;
  currency: string;
  isOpen: boolean;
  startDate: string;
  endDate?: string;
  createdAt: string;
  donorCount: number;
}

export interface Donation {
  id: string;
  campaignTitle: string;
  amount: number;
  currency: string;
  status: string;
  paymentMethod?: string;
  donatedAt: string;
  donorName: string;
}

// ─── Newsletter ──────────────────────────────────────
export interface SubscribeDto {
  email: string;
  fullName?: string;
}

// ─── Site Settings ───────────────────────────────────
export interface SiteSettings {
  id: string;
  heroBadgeText: string;
  heroTitle: string;
  heroSubtitle: string;
  primaryButtonText: string;
  secondaryButtonText: string;
  visionTitle: string;
  visionContent: string;
  missionTitle: string;
  missionContent: string;
  logoUrl?: string;
  beneficiaries: string;
  certificateThankYouMessage: string;
  updatedAt: string;
}

// ─── Admin ───────────────────────────────────────────
export interface DashboardStats {
  totalUsers: number;
  totalNews: number;
  totalEvents: number;
  activeCampaigns: number;
  totalDonationsAmount: number;
  totalDonors: number;
  newsletterSubscribers: number;
  monthlyDonations: MonthlyDonation[];
  topCampaigns: CampaignSummary[];
}

export interface MonthlyDonation {
  year: number;
  month: number;
  totalAmount: number;
  donationCount: number;
}

export interface CampaignSummary {
  id: string;
  title: string;
  goalAmount: number;
  collectedAmount: number;
  progressPercentage: number;
}