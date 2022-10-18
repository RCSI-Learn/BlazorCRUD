namespace BlazorCRUD_UI.Data {
	public class SqlConfiguration {
		public string ConnectionString { get; }
		public SqlConfiguration(string ConnectionString) => this.ConnectionString = ConnectionString;
	}
}
