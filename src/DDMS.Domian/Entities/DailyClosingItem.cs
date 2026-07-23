using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class DailyClosingItem:AuditableEntity
    {
        private DailyClosingItem()
        {
        }

        private DailyClosingItem(
            Guid dailyClosingId,
            Guid productId,
            int soldCarton,
            int soldPiece,
            int returnCarton,
            int returnPiece,
            int damageCarton,
            int damagePiece)
        {
            DailyClosingId = dailyClosingId;
            ProductId = productId;
            SoldCarton = soldCarton;
            SoldPiece = soldPiece;
            ReturnCarton = returnCarton;
            ReturnPiece = returnPiece;
            DamageCarton = damageCarton;
            DamagePiece = damagePiece;
        }

        public Guid DailyClosingId { get; private set; }

        public Guid ProductId { get; private set; }

        public int SoldCarton { get; private set; }

        public int SoldPiece { get; private set; }

        public int ReturnCarton { get; private set; }

        public int ReturnPiece { get; private set; }

        public int DamageCarton { get; private set; }

        public int DamagePiece { get; private set; }

        public DailyClosing DailyClosing { get; private set; } = null!;

        public Product Product { get; private set; } = null!;

        public static DailyClosingItem Create(
            Guid dailyClosingId,
            Guid productId,
            int soldCarton,
            int soldPiece,
            int returnCarton,
            int returnPiece,
            int damageCarton,
            int damagePiece)
        {
            return new DailyClosingItem(
                dailyClosingId,
                productId,
                soldCarton,
                soldPiece,
                returnCarton,
                returnPiece,
                damageCarton,
                damagePiece);
        }
    }
}
