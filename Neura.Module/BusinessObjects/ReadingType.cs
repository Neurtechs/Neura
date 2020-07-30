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
    public class ReadingType : XPCustomObject
    {
        public ReadingType(Session session) : base(session) { }

        int fOid;
        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        private ReadingsType _readingstype;
        [RuleRequiredField(DefaultContexts.Save)]
        [ColumnDefaultValue(0)]
        public ReadingsType ReadingsType
        {
            get { return _readingstype; }
            set { SetPropertyValue("ReadingsType", ref _readingstype, value); }
        }
        private double _startValue;
        [ColumnDefaultValue(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public double StartValue
        {
            get { return _startValue; }
            set
            {
                SetPropertyValue("StartValue",
              ref _startValue, value);
            }
        }

        //Child
        Node fNode;
        [RuleRequiredField(DefaultContexts.Save)]
        [Association(@"ReadingTypeReferencesNode")]
        public Node Node
        {
            get { return fNode; }
            set { SetPropertyValue<Node>(nameof(Node), ref fNode, value); }
        }
    }
    public enum ReadingsType {NA, Import, Export, Consumption, Generation }
}
