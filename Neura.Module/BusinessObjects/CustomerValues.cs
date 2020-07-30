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
    public class CustomerValues  : XPCustomObject
    {
        public CustomerValues(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        decimal fCost;
        public decimal Cost
        {
            get { return fCost; }
            set { SetPropertyValue<decimal>(nameof(Cost), ref fCost, value); }
        }
        DateTime fDateReceived;
        public DateTime DateReceived
        {
            get { return fDateReceived; }
            set { SetPropertyValue<DateTime>(nameof(DateReceived), ref fDateReceived, value); }
        }
        Customer fCustomer;
        [Association(@"CustomerValuesReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }

    }
}
