using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Neura.Module.BusinessObjects
{
    [NavigationItem("Registration")]
    // [DefaultClassOptions ]
    public class Gateway : XPCustomObject
    {
        public Gateway(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fGatewayName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
        public string GatewayName
        {
            get { return fGatewayName; }
            set { SetPropertyValue<string>(nameof(GatewayName), ref fGatewayName, value); }
        }

        string fSerialNo;
        [Size(45)]
        [RuleUniqueValue(DefaultContexts.Save)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string SerialNo
        {
            get { return fSerialNo; }
            set { SetPropertyValue<string>(nameof(SerialNo), ref fSerialNo, value); }
        }
        string fMacAddress;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
        public string MacAddress
        {
            get { return fMacAddress; }
            set { SetPropertyValue<string>(nameof(MacAddress), ref fMacAddress, value); }
        }
        string fIpAddress;
        [Size(45)]
        public string IpAddress
        {
            get { return fIpAddress; }
            set { SetPropertyValue<string>(nameof(IpAddress), ref fIpAddress, value); }
        }
        DateTime fInstallDate = DateTime.Now;
        public DateTime InstallDate
        {
            get { return fInstallDate; }
            set { SetPropertyValue<DateTime>(nameof(InstallDate), ref fInstallDate, value); }
        }
        string fInstaller;
        [Size(45)]
        public string Installer
        {
            get { return fInstaller; }
            set { SetPropertyValue<string>(nameof(Installer), ref fInstaller, value); }
        }
        string fSimNo;
        [Size(45)]
        public string SimNo
        {
            get { return fSimNo; }
            set { SetPropertyValue<string>(nameof(SimNo), ref fSimNo, value); }
        }
        string fSoftwareVer;
        [Size(45)]
        public string SoftwareVer
        {
            get { return fSoftwareVer; }
            set { SetPropertyValue<string>(nameof(SoftwareVer), ref fSoftwareVer, value); }
        }
        string fHardwareVer;
        [Size(45)]
        public string HardwareVer
        {
            get { return fHardwareVer; }
            set { SetPropertyValue<string>(nameof(HardwareVer), ref fHardwareVer, value); }
        }

        //User fCustomer;
        //[RuleRequiredField(DefaultContexts.Save)]
        //[Association(@"GatewayReferencesCustomer")]
        //public User Customer
        //{
        //    get { return fCustomer; }
        //    set { SetPropertyValue<User>(nameof(Customer), ref fCustomer, value); }
        //}



        Location fLocation;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association(@"GatewayReferencesLocation")]
        public Location Location
        {
            get { return fLocation; }
            set { SetPropertyValue<Location>(nameof(Location), ref fLocation, value); }
        }
        [Association(@"CustomerGatewayReferencesGateway")]
        public XPCollection<CustomerGateway> CustomerGateways { get { return GetCollection<CustomerGateway>(nameof(CustomerGateways)); } }

        [Association(@"NodeReferencesGateway")]

        public XPCollection<Node> Nodes { get { return GetCollection<Node>(nameof(Nodes)); } }
    }
}
