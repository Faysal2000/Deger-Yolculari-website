import { useState, useRef, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { Menu, X, ChevronDown } from 'lucide-react';
import { useAuth } from '../../context/AuthContext';
// import { useQuery } from '@tanstack/react-query';
// import axiosInstance from '../../api/axiosInstance';

import logo from '../../assets/logo4.jpeg';


const primaryLinks = [
  { label: 'Ana Sayfa', path: '/' },
  { label: 'Kampanyalar', path: '/kampanyalar' },
  { label: 'Haberler', path: '/haberler' },
  { label: 'Duyurular', path: '/duyurular' },
  // { label: 'Galeri', path: '/galeri' },
  { label: 'Hakkımızda', path: '/vizyon-misyon' },
];

const moreLinks = [
  
  { label: 'Etkinlikler', path: '/etkinlikler' },
  { label: 'Köşe Yazıları', path: '/kose-yazilari' },
  { label: 'Belgeler', path: '/belgeler' },
  // { label: 'Kampanyalar', path: '/kampanyalar' },
];

const Navbar = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [isMobile, setIsMobile] = useState(window.innerWidth < 768);
  const { isAuthenticated, isAdmin, logout, user } = useAuth();
  const location = useLocation();
  const dropdownRef = useRef<HTMLDivElement>(null);

  // const { data: settingsRes } = useQuery({
  //   queryKey: ['siteSettings'],
  //   queryFn: () => axiosInstance.get('/sitesettings').then(r => r.data),
  //   staleTime: 5 * 60 * 1000,
  // });
  // const logoUrl: string | undefined = settingsRes?.data?.logoUrl;

  useEffect(() => {
    const handleResize = () => setIsMobile(window.innerWidth < 768);
    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  useEffect(() => {
    if (!dropdownOpen) return;
    const handleClickOutside = (e: MouseEvent) => {
      if (dropdownRef.current && !dropdownRef.current.contains(e.target as Node)) {
        setDropdownOpen(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, [dropdownOpen]);

  // Close mobile menu on route change
  useEffect(() => {
    setMenuOpen(false);
    setDropdownOpen(false);
  }, [location.pathname]);

  const isActive = (path: string) =>
    path === '/' ? location.pathname === '/' : location.pathname.startsWith(path);

  const linkColor = (path: string) => (isActive(path) ? '#2E9DB5' : '#7DD4E8');

  return (
    <nav style={{ background: '#1A3A4A', position: 'sticky', top: 0, zIndex: 50, boxShadow: '0 2px 8px rgba(0,0,0,0.2)' }}>
      <div style={{ maxWidth: '1280px', margin: '0 auto', padding: '0 24px' }}>
        <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', height: '64px' }}>

          {/* Logo */}
          <Link to="/" style={{ display: 'flex', alignItems: 'center', gap: '10px', textDecoration: 'none', flexShrink: 0 }}>
            <div style={{ width: '40px', height: '40px', background: '#2E9DB5', borderRadius: '50%', display: 'flex', alignItems: 'center', justifyContent: 'center', overflow: 'hidden', flexShrink: 0 }}>
              {<img src={logo} alt="Logo" style={{ width: '100%', height: '100%', objectFit: 'cover' }} />}
            </div>
            <span style={{ color: 'white', fontWeight: 500, fontSize: '15px', whiteSpace: 'nowrap' }}>Değer Yolcuları</span>
            
          </Link>

          {/* Desktop nav */}
          {!isMobile && (
            <div style={{ display: 'flex', alignItems: 'center', gap: '24px' }}>
              {primaryLinks.map(link => (
                <Link
                  key={link.path}
                  to={link.path}
                  style={{ fontSize: '14px', textDecoration: 'none', color: linkColor(link.path), fontWeight: isActive(link.path) ? 500 : 400, transition: 'color 0.2s' }}
                  onMouseEnter={e => { if (!isActive(link.path)) e.currentTarget.style.color = 'white'; }}
                  onMouseLeave={e => { if (!isActive(link.path)) e.currentTarget.style.color = '#7DD4E8'; }}
                >
                  {link.label}
                </Link>
              ))}

              {/* Daha Fazla dropdown */}
              <div ref={dropdownRef} style={{ position: 'relative' }}>
                <button
                  onClick={() => setDropdownOpen(v => !v)}
                  style={{ display: 'flex', alignItems: 'center', gap: '4px', background: 'none', border: 'none', cursor: 'pointer', fontSize: '14px', color: '#7DD4E8', padding: 0, transition: 'color 0.2s' }}
                  onMouseEnter={e => (e.currentTarget.style.color = 'white')}
                  onMouseLeave={e => (e.currentTarget.style.color = '#7DD4E8')}
                >
                  Daha Fazla
                  <ChevronDown size={14} style={{ transition: 'transform 0.2s', transform: dropdownOpen ? 'rotate(180deg)' : 'rotate(0deg)' }} />
                </button>
                {dropdownOpen && (
                  <div style={{
                    position: 'absolute', top: 'calc(100% + 12px)', right: '-8px',
                    background: '#1A3A4A', border: '1px solid rgba(125,212,232,0.2)',
                    borderRadius: '10px', padding: '6px', minWidth: '160px', zIndex: 100,
                    boxShadow: '0 8px 24px rgba(0,0,0,0.25)',
                  }}>
                    {moreLinks.map(link => (
                      <Link
                        key={link.path}
                        to={link.path}
                        style={{ display: 'block', padding: '9px 14px', color: isActive(link.path) ? '#2E9DB5' : '#7DD4E8', fontSize: '13px', textDecoration: 'none', borderRadius: '6px', fontWeight: isActive(link.path) ? 500 : 400 }}
                        onMouseEnter={e => { e.currentTarget.style.background = 'rgba(255,255,255,0.08)'; }}
                        onMouseLeave={e => { e.currentTarget.style.background = 'transparent'; }}
                      >
                        {link.label}
                      </Link>
                    ))}
                  </div>
                )}
              </div>
            </div>
          )}

          {/* Desktop actions */}
          {!isMobile && (
            <div style={{ display: 'flex', alignItems: 'center', gap: '16px' }}>
              {isAdmin && (
                <Link to="/admin" style={{ fontSize: '13px', color: '#7DD4E8', textDecoration: 'none' }}
                  onMouseEnter={e => (e.currentTarget.style.color = 'white')}
                  onMouseLeave={e => (e.currentTarget.style.color = '#7DD4E8')}>
                  Yönetim
                </Link>
              )}
              {isAuthenticated ? (
                <button onClick={logout}
                  style={{ background: 'none', border: 'none', cursor: 'pointer', fontSize: '13px', color: '#7DD4E8', padding: 0 }}
                  onMouseEnter={e => (e.currentTarget.style.color = 'white')}
                  onMouseLeave={e => (e.currentTarget.style.color = '#7DD4E8')}>
                  Çıkış ({user?.fullName.split(' ')[0]})
                </button>
              ) : (
                <Link to="/login" style={{ fontSize: '13px', color: '#7DD4E8', textDecoration: 'none' }}
                  onMouseEnter={e => (e.currentTarget.style.color = 'white')}
                  onMouseLeave={e => (e.currentTarget.style.color = '#7DD4E8')}>
                  Giriş Yap
                </Link>
              )}
              <Link to="/kampanyalar"
                style={{ background: '#2E9DB5', color: 'white', fontSize: '13px', fontWeight: 500, padding: '8px 16px', borderRadius: '8px', textDecoration: 'none', transition: 'background 0.2s' }}
                onMouseEnter={e => (e.currentTarget.style.background = '#3BB5CF')}
                onMouseLeave={e => (e.currentTarget.style.background = '#2E9DB5')}>
                Bağış Yap
              </Link>
            </div>
          )}

          {/* Mobile hamburger */}
          {isMobile && (
            <button onClick={() => setMenuOpen(v => !v)}
              style={{ background: 'none', border: 'none', cursor: 'pointer', color: 'white', padding: '4px', display: 'flex' }}
              aria-label="Menü">
              {menuOpen ? <X size={24} /> : <Menu size={24} />}
            </button>
          )}
        </div>
      </div>

      {/* Mobile menu */}
      {isMobile && menuOpen && (
        <div style={{ background: '#1A3A4A', borderTop: '1px solid rgba(125,212,232,0.15)', padding: '12px 24px 20px' }}>
          {[...primaryLinks, ...moreLinks].map(link => (
            <Link
              key={link.path}
              to={link.path}
              style={{ display: 'block', padding: '11px 0', color: isActive(link.path) ? '#2E9DB5' : '#7DD4E8', fontSize: '14px', textDecoration: 'none', borderBottom: '1px solid rgba(125,212,232,0.08)', fontWeight: isActive(link.path) ? 500 : 400 }}
            >
              {link.label}
            </Link>
          ))}
          <div style={{ marginTop: '16px', display: 'flex', flexDirection: 'column', gap: '10px' }}>
            <Link to="/kampanyalar"
              style={{ background: '#2E9DB5', color: 'white', fontSize: '14px', fontWeight: 500, padding: '10px', borderRadius: '8px', textDecoration: 'none', textAlign: 'center' }}>
              Bağış Yap
            </Link>
            {isAdmin && (
              <Link to="/admin"
                style={{ color: '#7DD4E8', fontSize: '13px', textDecoration: 'none', textAlign: 'center', padding: '6px 0' }}>
                Yönetim Paneli
              </Link>
            )}
            {isAuthenticated ? (
              <button onClick={() => { logout(); setMenuOpen(false); }}
                style={{ background: 'none', border: 'none', cursor: 'pointer', color: '#7DD4E8', fontSize: '13px', padding: '6px 0', textAlign: 'center' }}>
                Çıkış Yap
              </button>
            ) : (
              <Link to="/login"
                style={{ color: '#7DD4E8', fontSize: '13px', textDecoration: 'none', textAlign: 'center', padding: '6px 0' }}>
                Giriş Yap
              </Link>
            )}
          </div>
        </div>
      )}
    </nav>
  );
};

export default Navbar;
