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
    public class Node : XPCustomObject
    {
        public Node(Session session) : base(session) { }
        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fNodeName;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
        public string NodeName
        {
            get { return fNodeName; }
            set { SetPropertyValue<string>(nameof(NodeName), ref fNodeName, value); }
        }

        string fSerialNo;
        [Size(45)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)]
        public string SerialNo
        {
            get { return fSerialNo; }
            set { SetPropertyValue<string>(nameof(SerialNo), ref fSerialNo, value); }
        }
        //int fNodeType;
        //public int NodeType
        //{
        //    get { return fNodeType; }
        //    set { SetPropertyValue<int>(nameof(NodeType), ref fNodeType, value); }
        //}
        //int fMeterType;
        //public int MeterType
        //{
        //    get { return fMeterType; }
        //    set { SetPropertyValue<int>(nameof(MeterType), ref fMeterType, value); }
        //}
        private NodeType _nodetype;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public NodeType NodeType
        {
            get { return _nodetype; }
            set { SetPropertyValue("NodeType", ref _nodetype, value); }
        }
        private MeterType _metertype;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public MeterType MeterType
        {
            get { return _metertype; }
            set { SetPropertyValue("MeterType", ref _metertype, value); }
        }

        //int fUnit;
        //public int Unit
        //{
        //    get { return fUnit; }
        //    set { SetPropertyValue<int>(nameof(Unit), ref fUnit, value); }
        //}

        private Unit _unit;
        [RuleRequiredField(DefaultContexts.Save)]
        [ColumnDefaultValue(0)]
        public Unit Unit
        {
            get { return _unit; }
            set { SetPropertyValue("Unit", ref _unit, value); }
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



        string fInstaller;
        [Size(45)]
        public string Installer
        {
            get { return fInstaller; }
            set { SetPropertyValue<string>(nameof(Installer), ref fInstaller, value); }
        }
        DateTime fInstallDate;
        public DateTime InstallDate
        {
            get { return fInstallDate; }
            set { SetPropertyValue<DateTime>(nameof(InstallDate), ref fInstallDate, value); }
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


        //Child
        Gateway fGateway;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association(@"NodeReferencesGateway")]
        public Gateway Gateway
        {
            get { return fGateway; }
            set { SetPropertyValue<Gateway>(nameof(Gateway), ref fGateway, value); }
        }



        //Child (Many) side
        private Tariff fTariff;
        [Association(@"NodeReferencesTariff")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Tariff Tariff
        {
            get { return fTariff; }
            set { SetPropertyValue("Tariff", ref fTariff, value); }
        }
        [Association(@"ReadingTypeReferencesNode")]

        public XPCollection<ReadingType> ReadingTypes { get { return GetCollection<ReadingType>(nameof(ReadingTypes)); } }

        [Association(@"PeriodValuesReferencesNode")]
        public XPCollection<PeriodValues> PeriodValuesCollection { get { return GetCollection<PeriodValues>(nameof(PeriodValuesCollection)); } }
    }
    public enum NodeType { ENode, WNode, GNode }
    public enum MeterType { kWhAcc, kWhP, kW, klAcc, klP, NA }
    public enum Unit { kWh, kW, kl, NA }
}
