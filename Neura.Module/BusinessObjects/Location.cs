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
    [ImageName("BO_Address")]
    public class Location : XPCustomObject
    {
        public Location(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fLocationName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string LocationName
        {
            get { return fLocationName; }
            set { SetPropertyValue<string>(nameof(LocationName), ref fLocationName, value); }
        }

        string fLatitude;
        [RuleRequiredField(DefaultContexts.Save)]
        public string Latitude
        {
            get { return fLatitude; }
            set { SetPropertyValue<string>(nameof(Latitude), ref fLatitude, value); }
        }
        string fLongitude;
        [RuleRequiredField(DefaultContexts.Save)]
        public string Longitude
        {
            get { return fLongitude; }
            set { SetPropertyValue<string>(nameof(Longitude), ref fLongitude, value); }
        }
        string fStreetAddress;
        [RuleRequiredField(DefaultContexts.Save)]
        public string StreetAddress
        {
            get { return fStreetAddress; }
            set { SetPropertyValue<string>(nameof(StreetAddress), ref fStreetAddress, value); }
        }
        string fUnitNo;
        [Size(45)]
        public string UnitNo
        {
            get { return fUnitNo; }
            set { SetPropertyValue<string>(nameof(UnitNo), ref fUnitNo, value); }
        }
        string fSuburb;
        [Size(45)]
        public string Suburb
        {
            get { return fSuburb; }
            set { SetPropertyValue<string>(nameof(Suburb), ref fSuburb, value); }
        }
        string fCity;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string City
        {
            get { return fCity; }
            set { SetPropertyValue<string>(nameof(City), ref fCity, value); }
        }
        string fCountry;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Country
        {
            get { return fCountry; }
            set { SetPropertyValue<string>(nameof(Country), ref fCountry, value); }
        }
        string fZip_PostalCode;
        [Size(45)]
        [Persistent(@"Zip_PostalCode")]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Zip_PostalCode
        {
            get { return fZip_PostalCode; }
            set { SetPropertyValue<string>(nameof(Zip_PostalCode), ref fZip_PostalCode, value); }
        }

        private DwellingType _dwellingType;
        [RuleRequiredField(DefaultContexts.Save)]
        [ColumnDefaultValue(0)]
        public DwellingType DwellingType
        {
            get { return _dwellingType; }
            set { SetPropertyValue("DwellingType", ref _dwellingType, value); }
        }


        string fZone;
        [Size(45)]
        public string Zone
        {
            get { return fZone; }
            set { SetPropertyValue<string>(nameof(Zone), ref fZone, value); }
        }




        string fCommunity;
        [Size(45)]
        [Persistent(@"Community_ComplexName")]
        public string Community_ComplexName
        {
            get { return fCommunity; }
            set { SetPropertyValue<string>(nameof(Community_ComplexName), ref fCommunity, value); }
        }

        ConcessionArea fConcessionArea;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association(@"LocationReferencesConcessionArea")]
        public ConcessionArea ConcessionArea
        {
            get { return fConcessionArea; }
            set { SetPropertyValue<ConcessionArea>(nameof(ConcessionArea), ref fConcessionArea, value); }
        }

        [Association(@"GatewayReferencesLocation")]
        public XPCollection<Gateway> Gateways { get { return GetCollection<Gateway>(nameof(Gateways)); } }
    }
    public enum DwellingType { FreeStandingHouse, Apartment, GuestHouse, MobileHome, Institutional, Commercial }
}
