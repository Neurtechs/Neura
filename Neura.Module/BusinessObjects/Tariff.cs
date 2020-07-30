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
    [NavigationItem("Tariffs")]
    public class Tariff : XPCustomObject
    {
        public Tariff(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fTariffName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string TariffName
        {
            get { return fTariffName; }
            set { SetPropertyValue<string>(nameof(TariffName), ref fTariffName, value); }
        }
        string fDescription;
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        private Service _service;
        [RuleRequiredField(DefaultContexts.Save)]
        public Service Service
        {
            get { return _service; }
            set { SetPropertyValue("Service", ref _service, value); }
        }
        [RuleRequiredField(DefaultContexts.Save)]
        public bool AllowNegative { get; set; }
        //int fService;
        //public int Service
        //{
        //    get { return fService; }
        //    set { SetPropertyValue<int>(nameof(Service), ref fService, value); }
        //}
        //int fAllowNegative;
        //public int AllowNegative
        //{
        //    get { return fAllowNegative; }
        //    set { SetPropertyValue<int>(nameof(AllowNegative), ref fAllowNegative, value); }
        //}


        Retailer fRetailer;
        [Association(@"TariffReferencesRetailer")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Retailer Retailer
        {
            get { return fRetailer; }
            set { SetPropertyValue<Retailer>(nameof(Retailer), ref fRetailer, value); }
        }
        TOULookup fTOULookup;
        [Association(@"TariffReferencesTOULookup")]
        [RuleRequiredField(DefaultContexts.Save)]
        public TOULookup TOULookup
        {
            get { return fTOULookup; }
            set { SetPropertyValue<TOULookup>(nameof(TOULookup), ref fTOULookup, value); }
        }
        [Association(@"TariffComponentReferencesTariff")]
        public XPCollection<TariffComponent> TariffComponents { get { return GetCollection<TariffComponent>(nameof(TariffComponents)); } }

        //Parent (One) side
        [Association(@"NodeReferencesTariff")]
        public XPCollection<Node> Nodes { get { return GetCollection<Node>("Nodes"); } }
    }
}
