// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from test on 2016-04-16 21:05:15Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace Tpu.NoSql.Sql
{
	using System;
	using System.ComponentModel;
	using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
	using System.Diagnostics;
	
	
	public partial class TestContext : DataContext
	{
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
		
		
		public TestContext(string connectionString) : 
				base(connectionString)
		{
			this.OnCreated();
		}
		
		public TestContext(string connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public TestContext(IDbConnection connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public Table<Customer> Customer
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public Table<Offer> Offer
		{
			get
			{
				return this.GetTable<Offer>();
			}
		}
		
		public Table<Purchase> Purchase
		{
			get
			{
				return this.GetTable<Purchase>();
			}
		}
	}
	
	#region Start MONO_STRICT
#if MONO_STRICT

	public partial class TestContext
	{
		
		public TestContext(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
	#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT
	
	public partial class TestContext
	{
		
		public TestContext(IDbConnection connection) : 
				base(connection, new DbLinq.PostgreSql.PgsqlVendor())
		{
			this.OnCreated();
		}
		
		public TestContext(IDbConnection connection, IVendor sqlDialect) : 
				base(connection, sqlDialect)
		{
			this.OnCreated();
		}
		
		public TestContext(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
				base(connection, mappingSource, sqlDialect)
		{
			this.OnCreated();
		}
	}
	#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
	#endregion
	
	[Table(Name="public.customer")]
	public partial class Customer : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged, DbLinq.Data.Linq.IInsertSqlEntity
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private System.DateTime _birth;
		
		private int _id;
		
		private string _name;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnBirthChanged();
		
		partial void OnBirthChanging(System.DateTime value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		#endregion
		
		
		public Customer()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_birth", Name="birth", DbType="timestamp without time zone", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public System.DateTime Birth
		{
			get
			{
				return this._birth;
			}
			set
			{
				if ((_birth != value))
				{
					this.OnBirthChanging(value);
					this.SendPropertyChanging();
					this._birth = value;
					this.SendPropertyChanged("Birth");
					this.OnBirthChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="id", DbType="integer(32,0)", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false, Expression="nextval(\'customer_id_seq\')")]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		public string InsertSql
		{
			get
			{
				string insertString = "";
				insertString = (insertString + "(");
				insertString = (insertString + "\'");
				insertString = (insertString + this.Birth.ToString("yyyy.MM.dd HH:mm:ss.fffffff").Replace("\'", "\'\'"));
				insertString = (insertString + "\'");
				insertString = (insertString + ", ");
				insertString = (insertString + "nextval(\'customer_id_seq\')");
				insertString = (insertString + ", ");
				if ((this.Name != null))
				{
					insertString = (insertString + "\'");
					insertString = (insertString + this.Name.ToString().Replace("\'", "\'\'"));
					insertString = (insertString + "\'");
				}
				else
				{
					insertString = (insertString + "null");
				}
				insertString = (insertString + ")");
				return insertString;
			}
		}
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="public.offer")]
	public partial class Offer : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged, DbLinq.Data.Linq.IInsertSqlEntity
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private bool _available;
		
		private long _barCode;
		
		private int _categoryID;
		
		private string _description;
		
		private int _id;
		
		private string _name;
		
		private System.Collections.Generic.Dictionary<string, string> _parameters;
		
		private double _price;
		
		private string _vendor;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAvailableChanged();
		
		partial void OnAvailableChanging(bool value);
		
		partial void OnBarCodeChanged();
		
		partial void OnBarCodeChanging(long value);
		
		partial void OnCategoryIDChanged();
		
		partial void OnCategoryIDChanging(int value);
		
		partial void OnDescriptionChanged();
		
		partial void OnDescriptionChanging(string value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		
		partial void OnParametersChanged();
		
		partial void OnParametersChanging(System.Collections.Generic.Dictionary<string, string> value);
		
		partial void OnPriceChanged();
		
		partial void OnPriceChanging(double value);
		
		partial void OnVendorChanged();
		
		partial void OnVendorChanging(string value);
		#endregion
		
		
		public Offer()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_available", Name="available", DbType="boolean", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public bool Available
		{
			get
			{
				return this._available;
			}
			set
			{
				if ((_available != value))
				{
					this.OnAvailableChanging(value);
					this.SendPropertyChanging();
					this._available = value;
					this.SendPropertyChanged("Available");
					this.OnAvailableChanged();
				}
			}
		}
		
		[Column(Storage="_barCode", Name="barcode", DbType="bigint(64,0)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public long BarCode
		{
			get
			{
				return this._barCode;
			}
			set
			{
				if ((_barCode != value))
				{
					this.OnBarCodeChanging(value);
					this.SendPropertyChanging();
					this._barCode = value;
					this.SendPropertyChanged("BarCode");
					this.OnBarCodeChanged();
				}
			}
		}
		
		[Column(Storage="_categoryID", Name="category_id", DbType="integer(32,0)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CategoryID
		{
			get
			{
				return this._categoryID;
			}
			set
			{
				if ((_categoryID != value))
				{
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._categoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[Column(Storage="_description", Name="description", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				if (((_description == value) 
							== false))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="id", DbType="integer(32,0)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_parameters", Name="parameters", DbType="USER-DEFINED", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Collections.Generic.Dictionary<string, string> Parameters
		{
			get
			{
				return this._parameters;
			}
			set
			{
				if (((_parameters == value) 
							== false))
				{
					this.OnParametersChanging(value);
					this.SendPropertyChanging();
					this._parameters = value;
					this.SendPropertyChanged("Parameters");
					this.OnParametersChanged();
				}
			}
		}
		
		[Column(Storage="_price", Name="price", DbType="double precision", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public double Price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((_price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[Column(Storage="_vendor", Name="vendor", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Vendor
		{
			get
			{
				return this._vendor;
			}
			set
			{
				if (((_vendor == value) 
							== false))
				{
					this.OnVendorChanging(value);
					this.SendPropertyChanging();
					this._vendor = value;
					this.SendPropertyChanged("Vendor");
					this.OnVendorChanged();
				}
			}
		}
		
		public string InsertSql
		{
			get
			{
				string insertString = "";
				insertString = (insertString + "(");
				insertString = (insertString + this.Available.ToString().ToUpper());
				insertString = (insertString + ", ");
				insertString = (insertString + this.BarCode.ToString());
				insertString = (insertString + ", ");
				insertString = (insertString + this.CategoryID.ToString());
				insertString = (insertString + ", ");
				if ((this.Description != null))
				{
					insertString = (insertString + "\'");
					insertString = (insertString + this.Description.ToString().Replace("\'", "\'\'"));
					insertString = (insertString + "\'");
				}
				else
				{
					insertString = (insertString + "null");
				}
				insertString = (insertString + ", ");
				insertString = (insertString + this.ID.ToString());
				insertString = (insertString + ", ");
				if ((this.Name != null))
				{
					insertString = (insertString + "\'");
					insertString = (insertString + this.Name.ToString().Replace("\'", "\'\'"));
					insertString = (insertString + "\'");
				}
				else
				{
					insertString = (insertString + "null");
				}
				insertString = (insertString + ", ");
				if ((this.Parameters != null))
				{
					insertString = (insertString + "\'");
					insertString = (insertString + this.Parameters.ToHStoreString().Replace("\'", "\'\'"));
					insertString = (insertString + "\'");
				}
				else
				{
					insertString = (insertString + "null");
				}
				insertString = (insertString + ", ");
				insertString = (insertString + this.Price.ToString().Replace(',', '.'));
				insertString = (insertString + ", ");
				if ((this.Vendor != null))
				{
					insertString = (insertString + "\'");
					insertString = (insertString + this.Vendor.ToString().Replace("\'", "\'\'"));
					insertString = (insertString + "\'");
				}
				else
				{
					insertString = (insertString + "null");
				}
				insertString = (insertString + ")");
				return insertString;
			}
		}
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="public.purchase")]
	public partial class Purchase : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged, DbLinq.Data.Linq.IInsertSqlEntity
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _customerID;
		
		private System.DateTime _dateTime;
		
		private int _id;
		
		private int[] _offers;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnCustomerIDChanged();
		
		partial void OnCustomerIDChanging(int value);
		
		partial void OnDateTimeChanged();
		
		partial void OnDateTimeChanging(System.DateTime value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnOffersChanged();
		
		partial void OnOffersChanging(int[] value);
		#endregion
		
		
		public Purchase()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_customerID", Name="customer_id", DbType="integer(32,0)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CustomerID
		{
			get
			{
				return this._customerID;
			}
			set
			{
				if ((_customerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._customerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[Column(Storage="_dateTime", Name="datetime", DbType="timestamp without time zone", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public System.DateTime DateTime
		{
			get
			{
				return this._dateTime;
			}
			set
			{
				if ((_dateTime != value))
				{
					this.OnDateTimeChanging(value);
					this.SendPropertyChanging();
					this._dateTime = value;
					this.SendPropertyChanged("DateTime");
					this.OnDateTimeChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="id", DbType="integer(32,0)", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false, Expression="nextval(\'purchase_id_seq\')")]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_offers", Name="offers", DbType="ARRAY", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int[] Offers
		{
			get
			{
				return this._offers;
			}
			set
			{
				if (((_offers == value) 
							== false))
				{
					this.OnOffersChanging(value);
					this.SendPropertyChanging();
					this._offers = value;
					this.SendPropertyChanged("Offers");
					this.OnOffersChanged();
				}
			}
		}
		
		public string InsertSql
		{
			get
			{
				string insertString = "";
				insertString = (insertString + "(");
				insertString = (insertString + this.CustomerID.ToString());
				insertString = (insertString + ", ");
				insertString = (insertString + "\'");
				insertString = (insertString + this.DateTime.ToString("yyyy.MM.dd HH:mm:ss.fffffff").Replace("\'", "\'\'"));
				insertString = (insertString + "\'");
				insertString = (insertString + ", ");
				insertString = (insertString + "nextval(\'purchase_id_seq\')");
				insertString = (insertString + ", ");
				if ((this.Offers != null))
				{
					insertString = (insertString + "\'");
					insertString = (insertString + this.Offers.ToString().Replace("\'", "\'\'"));
					insertString = (insertString + "\'");
				}
				else
				{
					insertString = (insertString + "null");
				}
				insertString = (insertString + ")");
				return insertString;
			}
		}
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
