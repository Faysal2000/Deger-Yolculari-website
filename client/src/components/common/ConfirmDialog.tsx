interface ConfirmDialogProps {
  open: boolean;
  message?: string;
  onConfirm: () => void;
  onCancel: () => void;
}

const ConfirmDialog = ({ open, message = 'Silmek istediğinizden emin misiniz?', onConfirm, onCancel }: ConfirmDialogProps) => {
  if (!open) return null;

  return (
    <div
      onClick={onCancel}
      style={{ position: 'fixed', inset: 0, background: 'rgba(0,0,0,0.4)', zIndex: 1000, display: 'flex', alignItems: 'center', justifyContent: 'center', padding: '16px' }}
    >
      <div
        onClick={e => e.stopPropagation()}
        style={{ background: 'white', borderRadius: '12px', padding: '28px 24px', width: '100%', maxWidth: '380px', boxShadow: '0 16px 40px rgba(0,0,0,0.16)' }}
      >
        <p style={{ fontSize: '15px', color: '#1A3A4A', fontWeight: 500, margin: '0 0 24px', lineHeight: 1.5, textAlign: 'center' }}>
          {message}
        </p>
        <div style={{ display: 'flex', gap: '10px', justifyContent: 'center' }}>
          <button
            onClick={onCancel}
            style={{ flex: 1, padding: '10px', border: '1px solid #E2E6EA', borderRadius: '8px', background: 'white', color: '#6B7280', fontSize: '13px', fontWeight: 500, cursor: 'pointer' }}
          >
            İptal
          </button>
          <button
            onClick={onConfirm}
            style={{ flex: 1, padding: '10px', border: 'none', borderRadius: '8px', background: '#C0392B', color: 'white', fontSize: '13px', fontWeight: 500, cursor: 'pointer' }}
          >
            Sil
          </button>
        </div>
      </div>
    </div>
  );
};

export default ConfirmDialog;
