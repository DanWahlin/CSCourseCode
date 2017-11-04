﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("HRSkillsModel", "Reference_Employee", "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(HRSkillsOnline.Employee), "References", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(HRSkillsOnline.Reference), true)]
[assembly: EdmRelationshipAttribute("HRSkillsModel", "Skill_Employee", "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(HRSkillsOnline.Employee), "Skills", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(HRSkillsOnline.Skill), true)]
[assembly: EdmRelationshipAttribute("HRSkillsModel", "SkillInfo_Skill", "Skills", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(HRSkillsOnline.Skill), "SkillInfo", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(HRSkillsOnline.SkillInfo), true)]

#endregion

namespace HRSkillsOnline
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class HRSkillsEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new HRSkillsEntities object using the connection string found in the 'HRSkillsEntities' section of the application configuration file.
        /// </summary>
        public HRSkillsEntities() : base("name=HRSkillsEntities", "HRSkillsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HRSkillsEntities object.
        /// </summary>
        public HRSkillsEntities(string connectionString) : base(connectionString, "HRSkillsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HRSkillsEntities object.
        /// </summary>
        public HRSkillsEntities(EntityConnection connection) : base(connection, "HRSkillsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Employee> Employees
        {
            get
            {
                if ((_Employees == null))
                {
                    _Employees = base.CreateObjectSet<Employee>("Employees");
                }
                return _Employees;
            }
        }
        private ObjectSet<Employee> _Employees;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Reference> References
        {
            get
            {
                if ((_References == null))
                {
                    _References = base.CreateObjectSet<Reference>("References");
                }
                return _References;
            }
        }
        private ObjectSet<Reference> _References;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SkillInfo> SkillInfoes
        {
            get
            {
                if ((_SkillInfoes == null))
                {
                    _SkillInfoes = base.CreateObjectSet<SkillInfo>("SkillInfoes");
                }
                return _SkillInfoes;
            }
        }
        private ObjectSet<SkillInfo> _SkillInfoes;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Skill> Skills
        {
            get
            {
                if ((_Skills == null))
                {
                    _Skills = base.CreateObjectSet<Skill>("Skills");
                }
                return _Skills;
            }
        }
        private ObjectSet<Skill> _Skills;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the References EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToReferences(Reference reference)
        {
            base.AddObject("References", reference);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the SkillInfoes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSkillInfoes(SkillInfo skillInfo)
        {
            base.AddObject("SkillInfoes", skillInfo);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Skills EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSkills(Skill skill)
        {
            base.AddObject("Skills", skill);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HRSkillsModel", Name="Employee")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Employee : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name="employeeId">Initial value of the EmployeeId property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="alias">Initial value of the Alias property.</param>
        public static Employee CreateEmployee(global::System.Guid employeeId, global::System.String lastName, global::System.String alias)
        {
            Employee employee = new Employee();
            employee.EmployeeId = employeeId;
            employee.LastName = lastName;
            employee.Alias = alias;
            return employee;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                if (_EmployeeId != value)
                {
                    OnEmployeeIdChanging(value);
                    ReportPropertyChanging("EmployeeId");
                    _EmployeeId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EmployeeId");
                    OnEmployeeIdChanged();
                }
            }
        }
        private global::System.Guid _EmployeeId;
        partial void OnEmployeeIdChanging(global::System.Guid value);
        partial void OnEmployeeIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Alias
        {
            get
            {
                return _Alias;
            }
            set
            {
                OnAliasChanging(value);
                ReportPropertyChanging("Alias");
                _Alias = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Alias");
                OnAliasChanged();
            }
        }
        private global::System.String _Alias;
        partial void OnAliasChanging(global::System.String value);
        partial void OnAliasChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HRSkillsModel", "Reference_Employee", "References")]
        public EntityCollection<Reference> References
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Reference>("HRSkillsModel.Reference_Employee", "References");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Reference>("HRSkillsModel.Reference_Employee", "References", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HRSkillsModel", "Skill_Employee", "Skills")]
        public EntityCollection<Skill> Skills
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Skill>("HRSkillsModel.Skill_Employee", "Skills");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Skill>("HRSkillsModel.Skill_Employee", "Skills", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HRSkillsModel", Name="Reference")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Reference : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Reference object.
        /// </summary>
        /// <param name="referenceId">Initial value of the ReferenceId property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="alias">Initial value of the Alias property.</param>
        /// <param name="employeeId">Initial value of the EmployeeId property.</param>
        public static Reference CreateReference(global::System.Guid referenceId, global::System.String lastName, global::System.String alias, global::System.Guid employeeId)
        {
            Reference reference = new Reference();
            reference.ReferenceId = referenceId;
            reference.LastName = lastName;
            reference.Alias = alias;
            reference.EmployeeId = employeeId;
            return reference;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ReferenceId
        {
            get
            {
                return _ReferenceId;
            }
            set
            {
                if (_ReferenceId != value)
                {
                    OnReferenceIdChanging(value);
                    ReportPropertyChanging("ReferenceId");
                    _ReferenceId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ReferenceId");
                    OnReferenceIdChanged();
                }
            }
        }
        private global::System.Guid _ReferenceId;
        partial void OnReferenceIdChanging(global::System.Guid value);
        partial void OnReferenceIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Position
        {
            get
            {
                return _Position;
            }
            set
            {
                OnPositionChanging(value);
                ReportPropertyChanging("Position");
                _Position = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Position");
                OnPositionChanged();
            }
        }
        private global::System.String _Position;
        partial void OnPositionChanging(global::System.String value);
        partial void OnPositionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Alias
        {
            get
            {
                return _Alias;
            }
            set
            {
                OnAliasChanging(value);
                ReportPropertyChanging("Alias");
                _Alias = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Alias");
                OnAliasChanged();
            }
        }
        private global::System.String _Alias;
        partial void OnAliasChanging(global::System.String value);
        partial void OnAliasChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                OnEmployeeIdChanging(value);
                ReportPropertyChanging("EmployeeId");
                _EmployeeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EmployeeId");
                OnEmployeeIdChanged();
            }
        }
        private global::System.Guid _EmployeeId;
        partial void OnEmployeeIdChanging(global::System.Guid value);
        partial void OnEmployeeIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HRSkillsModel", "Reference_Employee", "Employees")]
        public Employee Employee
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("HRSkillsModel.Reference_Employee", "Employees").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("HRSkillsModel.Reference_Employee", "Employees").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> EmployeeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("HRSkillsModel.Reference_Employee", "Employees");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("HRSkillsModel.Reference_Employee", "Employees", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HRSkillsModel", Name="Skill")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Skill : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Skill object.
        /// </summary>
        /// <param name="skillId">Initial value of the SkillId property.</param>
        /// <param name="employeeId">Initial value of the EmployeeId property.</param>
        /// <param name="skillName">Initial value of the SkillName property.</param>
        /// <param name="briefDescription">Initial value of the BriefDescription property.</param>
        public static Skill CreateSkill(global::System.Guid skillId, global::System.Guid employeeId, global::System.String skillName, global::System.String briefDescription)
        {
            Skill skill = new Skill();
            skill.SkillId = skillId;
            skill.EmployeeId = employeeId;
            skill.SkillName = skillName;
            skill.BriefDescription = briefDescription;
            return skill;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid SkillId
        {
            get
            {
                return _SkillId;
            }
            set
            {
                if (_SkillId != value)
                {
                    OnSkillIdChanging(value);
                    ReportPropertyChanging("SkillId");
                    _SkillId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("SkillId");
                    OnSkillIdChanged();
                }
            }
        }
        private global::System.Guid _SkillId;
        partial void OnSkillIdChanging(global::System.Guid value);
        partial void OnSkillIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                OnEmployeeIdChanging(value);
                ReportPropertyChanging("EmployeeId");
                _EmployeeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EmployeeId");
                OnEmployeeIdChanged();
            }
        }
        private global::System.Guid _EmployeeId;
        partial void OnEmployeeIdChanging(global::System.Guid value);
        partial void OnEmployeeIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String SkillName
        {
            get
            {
                return _SkillName;
            }
            set
            {
                OnSkillNameChanging(value);
                ReportPropertyChanging("SkillName");
                _SkillName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("SkillName");
                OnSkillNameChanged();
            }
        }
        private global::System.String _SkillName;
        partial void OnSkillNameChanging(global::System.String value);
        partial void OnSkillNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String BriefDescription
        {
            get
            {
                return _BriefDescription;
            }
            set
            {
                OnBriefDescriptionChanging(value);
                ReportPropertyChanging("BriefDescription");
                _BriefDescription = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("BriefDescription");
                OnBriefDescriptionChanged();
            }
        }
        private global::System.String _BriefDescription;
        partial void OnBriefDescriptionChanging(global::System.String value);
        partial void OnBriefDescriptionChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HRSkillsModel", "Skill_Employee", "Employees")]
        public Employee Employee
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("HRSkillsModel.Skill_Employee", "Employees").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("HRSkillsModel.Skill_Employee", "Employees").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> EmployeeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("HRSkillsModel.Skill_Employee", "Employees");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("HRSkillsModel.Skill_Employee", "Employees", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HRSkillsModel", "SkillInfo_Skill", "SkillInfo")]
        public EntityCollection<SkillInfo> SkillInfoes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SkillInfo>("HRSkillsModel.SkillInfo_Skill", "SkillInfo");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SkillInfo>("HRSkillsModel.SkillInfo_Skill", "SkillInfo", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HRSkillsModel", Name="SkillInfo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class SkillInfo : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new SkillInfo object.
        /// </summary>
        /// <param name="skillInfoId">Initial value of the SkillInfoId property.</param>
        /// <param name="uRL">Initial value of the URL property.</param>
        /// <param name="skillId">Initial value of the SkillId property.</param>
        public static SkillInfo CreateSkillInfo(global::System.Guid skillInfoId, global::System.String uRL, global::System.Guid skillId)
        {
            SkillInfo skillInfo = new SkillInfo();
            skillInfo.SkillInfoId = skillInfoId;
            skillInfo.URL = uRL;
            skillInfo.SkillId = skillId;
            return skillInfo;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid SkillInfoId
        {
            get
            {
                return _SkillInfoId;
            }
            set
            {
                if (_SkillInfoId != value)
                {
                    OnSkillInfoIdChanging(value);
                    ReportPropertyChanging("SkillInfoId");
                    _SkillInfoId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("SkillInfoId");
                    OnSkillInfoIdChanged();
                }
            }
        }
        private global::System.Guid _SkillInfoId;
        partial void OnSkillInfoIdChanging(global::System.Guid value);
        partial void OnSkillInfoIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String URL
        {
            get
            {
                return _URL;
            }
            set
            {
                OnURLChanging(value);
                ReportPropertyChanging("URL");
                _URL = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("URL");
                OnURLChanged();
            }
        }
        private global::System.String _URL;
        partial void OnURLChanging(global::System.String value);
        partial void OnURLChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid SkillId
        {
            get
            {
                return _SkillId;
            }
            set
            {
                OnSkillIdChanging(value);
                ReportPropertyChanging("SkillId");
                _SkillId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SkillId");
                OnSkillIdChanged();
            }
        }
        private global::System.Guid _SkillId;
        partial void OnSkillIdChanging(global::System.Guid value);
        partial void OnSkillIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("HRSkillsModel", "SkillInfo_Skill", "Skills")]
        public Skill Skill
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("HRSkillsModel.SkillInfo_Skill", "Skills").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("HRSkillsModel.SkillInfo_Skill", "Skills").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Skill> SkillReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Skill>("HRSkillsModel.SkillInfo_Skill", "Skills");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Skill>("HRSkillsModel.SkillInfo_Skill", "Skills", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}