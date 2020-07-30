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
    [NavigationItem("Registration")]
    public class Customer : XPCustomObject
    {
        public Customer(Session session) : base(session) { }
        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }

        string fCustomerName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
        public string CustomerName
        {
            get { return fCustomerName; }
            set { SetPropertyValue("CustomerName", ref fCustomerName, value); }
        }



        DateTime fCreateDate = DateTime.Now;
        [RuleRequiredField(DefaultContexts.Save)]
        public DateTime CreateDate
        {
            get { return fCreateDate; }
            set { SetPropertyValue<DateTime>(nameof(CreateDate), ref fCreateDate, value); }
        }
        string fCustomerId;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
        public string CustomerId
        {
            get { return fCustomerId; }
            set { SetPropertyValue<string>(nameof(CustomerId), ref fCustomerId, value); }
        }

        [Association(@"CustomerGatewayReferencesCustomer")]
        public XPCollection<CustomerGateway> CustomerGateways { get { return GetCollection<CustomerGateway>(nameof(CustomerGateways)); } }
        [Association(@"UserReferencesCustomer")]
        public XPCollection<User> Users { get { return GetCollection<User>(nameof(Users)); } }

        [Association(@"CustomerValuesReferencesCustomer")]
        public XPCollection<CustomerValues> CustomerValuesCollection { get { return GetCollection<CustomerValues>(nameof(CustomerValuesCollection)); } }

    }
}
