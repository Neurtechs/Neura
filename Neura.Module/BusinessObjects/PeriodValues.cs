using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;

namespace Neura.Module.BusinessObjects
{
    public class PeriodValues : XPCustomObject
    {
        public PeriodValues(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]

        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }

        decimal fuAcc;
        public decimal uAcc
        {
            get { return fuAcc; }
            set { SetPropertyValue<decimal>(nameof(uAcc), ref fuAcc, value); }
        }
        DateTime fDateReceived;
        public DateTime DateReceived
        {
            get { return fDateReceived; }
            set { SetPropertyValue<DateTime>(nameof(DateReceived), ref fDateReceived, value); }
        }

        Node fNode;
        [Association(@"PeriodValuesReferencesNode")]
        public Node Node
        {
            get { return fNode; }
            set { SetPropertyValue<Node>(nameof(Node), ref fNode, value); }
        }
    }
}
