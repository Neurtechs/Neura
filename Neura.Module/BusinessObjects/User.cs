using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;

namespace Neura.Module.BusinessObjects
{
    [NavigationItem("Registration")]
    public class User : XPCustomObject
    {
        public User(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        //string fRefNo;
        //[Size(45)]
        //[RuleRequiredField(DefaultContexts.Save)]
        //[RuleUniqueValue(DefaultContexts.Save)]
        //public string RefNo
        //{
        //    get { return fRefNo; }
        //    set { SetPropertyValue("RefNo", ref fRefNo, value); }
        //}
        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        public string FullName
        {
            get
            {
                return ObjectFormatter.Format("{FirstName} {LastName} ", this,
                    EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
            }
        }

        string fFirstName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string FirstName
        {
            get { return fFirstName; }
            set { SetPropertyValue("FirstName", ref fFirstName, value); }
        }
        string fLastName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string LastName
        {
            get { return fLastName; }
            set { SetPropertyValue("LastName", ref fLastName, value); }
        }
       

        string fEmail;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Email
        {
            get { return fEmail; }
            set { SetPropertyValue<string>(nameof(Email), ref fEmail, value); }
        }
        string fMobile;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Mobile
        {
            get { return fMobile; }
            set { SetPropertyValue<string>(nameof(Mobile), ref fMobile, value); }
        }
        string fLandline;
        [Size(45)]
        public string Landline
        {
            get { return fLandline; }
            set { SetPropertyValue<string>(nameof(Landline), ref fLandline, value); }
        }
        string fPostalAddress;

        public string PostalAddress
        {
            get { return fPostalAddress; }
            set { SetPropertyValue<string>(nameof(PostalAddress), ref fPostalAddress, value); }
        }
        //int fType;
        //[ColumnDefaultValue(0)]
        //public int Type
        //{
        //    get { return fType; }
        //    set { SetPropertyValue<int>(nameof(Type), ref fType, value); }
        //}

        private CustomerType _customertype;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public CustomerType CustomerType
        {
            get { return _customertype; }
            set { SetPropertyValue("CustomerType", ref _customertype, value); }
        }

        //int fStatus;
        //public int Status
        //{
        //    get { return fStatus; }
        //    set { SetPropertyValue<int>(nameof(Status), ref fStatus, value); }
        //}

        private Status _status;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public Status Status
        {
            get { return _status; }
            set { SetPropertyValue("Status", ref _status, value); }
        }
       
        Customer fCustomer;
        [Association(@"UserReferencesCustomer")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Customer Customer
        {
            get { return fCustomer; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomer, value); }
        }

    }
    public enum CustomerType { Domestic, Commercial, Industrial }
}
