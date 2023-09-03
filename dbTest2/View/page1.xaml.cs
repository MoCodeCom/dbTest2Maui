using System.Collections.ObjectModel;
using System.Reflection;
using dbTest2.Model;
using dbTest2.ModelView;

namespace dbTest2.View;

public partial class page1 : ContentPage
{
    //private readonly databaseContext _dbContext;
	public ObservableCollection<userModel> user { get; set; } = new ObservableCollection<userModel>();

    public page1()
	{
		InitializeComponent();
		//BindingContext = dbContext.GetAllUsers();
		//_dbContext = dbContext;
		initial();
		//App.Current.MainPage.DisplayAlert("title", dbContext.GetAllUsers().ToString(), "Ok");
	}

	private void initial()
	{
		var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
		using (Stream stream =
			assembly.GetManifestResourceStream("dbTest2.sqlDb.db3"))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);
				File.WriteAllBytes(databaseContext.DbPath, memoryStream.ToArray());
			}
		}

		databaseContext dbcontext = new databaseContext();
		foreach(var v in dbcontext.List())
		{
			user.Add(v);
		}

		BindingContext = this;
	}
}
