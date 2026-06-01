import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Heart, Mail, Phone, Send } from 'lucide-react';
import { useQuery, useMutation } from '@tanstack/react-query';
import axiosInstance from '../../api/axiosInstance';
import toast from 'react-hot-toast';

const contentLinks = [
  { label: 'Haberler', path: '/haberler' },
  { label: 'Etkinlikler', path: '/etkinlikler' },
  { label: 'Köşe Yazıları', path: '/kose-yazilari' },
  { label: 'Galeri', path: '/galeri' },
];

const corporateLinks = [
  { label: 'Vizyon & Misyon', path: '/vizyon-misyon' },
  { label: 'Duyurular', path: '/duyurular' },
  { label: 'Belgeler', path: '/belgeler' },
  { label: 'Kampanyalar', path: '/kampanyalar' },
];

const getCols = () => {
  const w = window.innerWidth;
  if (w >= 1024) return 4;
  if (w >= 640) return 2;
  return 1;
};

const Footer = () => {
  const [cols, setCols] = useState(getCols);
  const [email, setEmail] = useState('');

  useEffect(() => {
    const handleResize = () => setCols(getCols());
    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const { data: settingsRes } = useQuery({
    queryKey: ['siteSettings'],
    queryFn: () => axiosInstance.get('/sitesettings').then(r => r.data),
    staleTime: 5 * 60 * 1000,
  });
  const logoUrl: string | undefined = settingsRes?.data?.logoUrl;

  const subscribeMutation = useMutation({
    mutationFn: (mail: string) => axiosInstance.post('/newsletter/subscribe', { email: mail }),
    onSuccess: (res) => { toast.success(res.data?.message ?? 'Bültene başarıyla abone oldunuz!'); setEmail(''); },
    onError: (err: any) => toast.error(err?.response?.data?.errors?.[0] ?? 'Abonelik başarısız oldu.'),
  });

  const handleSubscribe = (e: React.FormEvent) => {
    e.preventDefault();
    if (!email.trim()) return;
    subscribeMutation.mutate(email.trim());
  };

  const linkStyle: React.CSSProperties = { color: '#7DD4E8', fontSize: '13px', textDecoration: 'none', display: 'block', padding: '3px 0', transition: 'color 0.2s' };

  return (
    <footer style={{ background: '#1A3A4A', color: 'white', marginTop: '64px' }}>
      <div style={{ maxWidth: '1280px', margin: '0 auto', padding: '48px 24px 0' }}>

        {/* Main grid */}
        <div style={{ display: 'grid', gridTemplateColumns: `repeat(${cols}, 1fr)`, gap: '32px', marginBottom: '40px' }}>

          {/* Col 1 – Logo + description + socials */}
          <div>
            <Link to="/" style={{ display: 'inline-flex', alignItems: 'center', gap: '10px', textDecoration: 'none', marginBottom: '14px' }}>
              <div style={{ width: '36px', height: '36px', background: '#2E9DB5', borderRadius: '50%', display: 'flex', alignItems: 'center', justifyContent: 'center', overflow: 'hidden', flexShrink: 0 }}>
                {logoUrl
                  ? <img src={logoUrl} alt="Logo" style={{ width: '100%', height: '100%', objectFit: 'cover' }} />
                  : <Heart size={15} color="white" fill="white" />}
              </div>
              <span style={{ fontWeight: 500, fontSize: '15px', color: 'white' }}>Değer Yolcuları</span>
            </Link>
            <p style={{ color: '#7DD4E8', fontSize: '13px', lineHeight: 1.7, marginBottom: '20px' }}>
              "Bilmekten Çok Yaşamak İçin" — Toplumun her kesimine ulaşmak ve kalıcı değişimler oluşturmak için çalışıyoruz.
            </p>
            <div style={{ display: 'flex', gap: '8px' }}>
              {(['IG', 'TW', 'FB'] as const).map(s => (
                <a key={s} href="#"
                  style={{ width: '34px', height: '34px', background: 'rgba(255,255,255,0.08)', borderRadius: '8px', display: 'flex', alignItems: 'center', justifyContent: 'center', textDecoration: 'none', transition: 'background 0.2s' }}
                  onMouseEnter={e => (e.currentTarget.style.background = '#2E9DB5')}
                  onMouseLeave={e => (e.currentTarget.style.background = 'rgba(255,255,255,0.08)')}
                  aria-label={s}>
                  <span style={{ color: '#7DD4E8', fontSize: '11px', fontWeight: 700 }}>{s}</span>
                </a>
              ))}
            </div>
          </div>

          {/* Col 2 – İçerik */}
          <div>
            <h3 style={{ fontSize: '13px', fontWeight: 600, color: 'white', margin: '0 0 16px', textTransform: 'uppercase', letterSpacing: '0.05em' }}>İçerik</h3>
            {contentLinks.map(link => (
              <Link key={link.path} to={link.path} style={linkStyle}
                onMouseEnter={e => (e.currentTarget.style.color = 'white')}
                onMouseLeave={e => (e.currentTarget.style.color = '#7DD4E8')}>
                {link.label}
              </Link>
            ))}
          </div>

          {/* Col 3 – Kurumsal */}
          <div>
            <h3 style={{ fontSize: '13px', fontWeight: 600, color: 'white', margin: '0 0 16px', textTransform: 'uppercase', letterSpacing: '0.05em' }}>Kurumsal</h3>
            {corporateLinks.map(link => (
              <Link key={link.path} to={link.path} style={linkStyle}
                onMouseEnter={e => (e.currentTarget.style.color = 'white')}
                onMouseLeave={e => (e.currentTarget.style.color = '#7DD4E8')}>
                {link.label}
              </Link>
            ))}
          </div>

          {/* Col 4 – İletişim */}
          <div>
            <h3 style={{ fontSize: '13px', fontWeight: 600, color: 'white', margin: '0 0 16px', textTransform: 'uppercase', letterSpacing: '0.05em' }}>İletişim</h3>
            <div style={{ display: 'flex', alignItems: 'center', gap: '8px', marginBottom: '10px' }}>
              <Mail size={14} color="#2E9DB5" style={{ flexShrink: 0 }} />
              <span style={{ color: '#7DD4E8', fontSize: '13px' }}>info@degeryolculari.org</span>
            </div>
            <div style={{ display: 'flex', alignItems: 'center', gap: '8px', marginBottom: '20px' }}>
              <Phone size={14} color="#2E9DB5" style={{ flexShrink: 0 }} />
              <span style={{ color: '#7DD4E8', fontSize: '13px' }}>+90 555 000 00 00</span>
            </div>
            <Link to="/kampanyalar"
              style={{ display: 'inline-block', background: '#2E9DB5', color: 'white', fontSize: '13px', fontWeight: 500, padding: '9px 18px', borderRadius: '8px', textDecoration: 'none', transition: 'background 0.2s' }}
              onMouseEnter={e => (e.currentTarget.style.background = '#3BB5CF')}
              onMouseLeave={e => (e.currentTarget.style.background = '#2E9DB5')}>
              Bağış Yap
            </Link>
          </div>
        </div>

        {/* Newsletter */}
        <div style={{ background: 'rgba(46,157,181,0.12)', borderRadius: '12px', padding: '24px', marginBottom: '32px', border: '1px solid rgba(46,157,181,0.2)' }}>
          <h3 style={{ fontSize: '14px', fontWeight: 600, color: 'white', margin: '0 0 6px' }}>Bültenimize Abone Olun</h3>
          <p style={{ fontSize: '12px', color: '#7DD4E8', margin: '0 0 16px' }}>Güncel haberler ve etkinlikler için e-posta listemize katılın.</p>
          <form onSubmit={handleSubscribe}
            style={{ display: 'flex', gap: '8px', flexDirection: cols === 1 ? 'column' : 'row' }}>
            <input
              type="email"
              value={email}
              onChange={e => setEmail(e.target.value)}
              placeholder="E-posta adresiniz"
              required
              style={{ flex: 1, padding: '10px 14px', borderRadius: '8px', border: '1px solid rgba(125,212,232,0.3)', background: 'rgba(255,255,255,0.06)', color: 'white', fontSize: '13px', outline: 'none', boxSizing: 'border-box' }}
              onFocus={e => (e.target.style.borderColor = '#2E9DB5')}
              onBlur={e => (e.target.style.borderColor = 'rgba(125,212,232,0.3)')}
            />
            <button
              type="submit"
              disabled={subscribeMutation.isPending}
              style={{ display: 'flex', alignItems: 'center', gap: '6px', background: '#2E9DB5', color: 'white', border: 'none', borderRadius: '8px', padding: '10px 18px', cursor: 'pointer', fontSize: '13px', fontWeight: 500, flexShrink: 0, opacity: subscribeMutation.isPending ? 0.7 : 1 }}>
              <Send size={14} />
              {subscribeMutation.isPending ? 'Gönderiliyor...' : 'Abone Ol'}
            </button>
          </form>
        </div>

        {/* Bottom bar */}
        <div style={{ borderTop: '1px solid rgba(125,212,232,0.12)', padding: '20px 0', display: 'flex', flexDirection: cols === 1 ? 'column' : 'row', alignItems: 'center', justifyContent: 'space-between', gap: '8px' }}>
          <p style={{ color: '#7DD4E8', fontSize: '12px', margin: 0 }}>© 2026 Değer Yolcuları. Tüm hakları saklıdır.</p>
          <p style={{ color: '#7DD4E8', fontSize: '12px', margin: 0 }}>Bilmekten Çok Yaşamak İçin</p>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
