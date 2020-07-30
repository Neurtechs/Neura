using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;

namespace Neura.Module.BusinessObjects
{
    [NavigationItem("Registration")]

    public class CustomerGateway : XPCustomObject
    {
        public CustomerGateway(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        bool fStatus;
        public bool Status
        {
            get { return fStatus; }
            set { SetPropertyValue<bool>(nameof(Status), ref fStatus, value); }
        }
        DateTime fCreateDate = DateTime.Now ;
     

        public DateTime CreateDate
        {
            
            get { return fCreateDate; }
            set { SetPropertyValue<DateTime>(nameof(CreateDate), ref fCreateDate, value); }
        }
        DateTime fUpdateDate = DateTime.Now;
        public DateTime UpdateDate
        {
            get { return fUpdateDate; }
            set { SetPropertyValue<DateTime>(nameof(UpdateDate), ref fUpdateDate, value); }
        }
        Customer fCustomer;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association(@"CustomerGatewayReferencesCustomer")]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }
        Gateway fGateway;
        [Association(@"CustomerGatewayReferencesGateway")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Gateway Gateway
        {
            get { return fGateway; }
            set { SetPropertyValue<Gateway>(nameof(Gateway), ref fGateway, value); }
        }
    }
}
