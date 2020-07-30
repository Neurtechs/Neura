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
    public class TariffComponent : XPCustomObject
    {
        
        public TariffComponent(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }

        string fTariffComponentName;
        [RuleRequiredField(DefaultContexts.Save)]
        public string TariffComponentName
        {
            get { return fTariffComponentName; }
            set { SetPropertyValue<string>(nameof(TariffComponentName), ref fTariffComponentName, value); }
        }

        private Measurement _measurement;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public Measurement Measurement
        {
            get { return _measurement; }
            set { SetPropertyValue("Measurement", ref _measurement, value); }
        }

        private Flow _flow;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
     
        public Flow Flow
        {
            get { return _flow; }
            set { SetPropertyValue("Flow", ref _flow, value); }
        }

        
        private Interval _interval;
        [ColumnDefaultValue(3)]
        [RuleRequiredField(DefaultContexts.Save)]
      
        public Interval Interval
        {
            get { return _interval; }
            set { SetPropertyValue("Interval", ref _interval, value); }
        }

        double fFloor;
        public double Floor
        {
            get { return fFloor; }
            set { SetPropertyValue<double>(nameof(Floor), ref fFloor, value); }
        }

        double fCeiling;
        public double Ceiling
        {
            get { return fCeiling; }
            set { SetPropertyValue<double>(nameof(Ceiling), ref fCeiling, value); }
        }

       

        private Season _season;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]

        public Season Season
        {
            get { return _season; }
            set { SetPropertyValue("Season", ref _season, value); }
        }
        private Period _period;
        [RuleRequiredField(DefaultContexts.Save)]
        [ColumnDefaultValue(0)]
        public Period Period
        {
            get { return _period; }
            set { SetPropertyValue("Period", ref _period, value); }
        }


        private Tariff fTariff;
        [Association(@"TariffComponentReferencesTariff")]
        public Tariff Tariff
        {
            get { return fTariff; }
            set { SetPropertyValue<Tariff>(nameof(Tariff), ref fTariff, value); }
        }
        [Association(@"TariffRateReferencesTariffComponent")]
        public XPCollection<TariffRate> TariffRates { get { return GetCollection<TariffRate>(nameof(TariffRates)); } }
    }
    public enum Measurement { Accumulated, Maximum, Fixed, MaxProgressive }
    public enum Interval { Peak, Standard, OffPeak, All, PeakAndStandard, NonEnergy }
    public enum Flow { NotApplicable,  Import, Export, Consumption, Generate, NetImportExport, NetImportExportGenerate }
    public enum Period { Account, Day, Month }
    public enum Season { High, Low, All, NotApplicable }
}
