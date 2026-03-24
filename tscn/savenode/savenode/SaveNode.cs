using Godot;
using SaveData;

public partial class SaveNode : Node
{
	[Export] public MetaData DefaultMetaData { get; set; } = new MetaData();
	[Export] public RunData DefaultRunData { get; set; } = new RunData();
	[Export] public SettingsData DefaultSettingsData { get; set; } = new SettingsData();
	[Export] public string SaveDirectory { get; set; } = "user://saves/";
	public MetaData MetaData { get; set; }
	public RunData RunData { get; set; }
	public SettingsData SettingsData { get; set; }

	public override void _Ready()
	{
		GD.Print(DefaultRunData + "testtest");
		ExecuteReady();
	}

	public void ExecuteReady()
	{
		DirAccess.MakeDirRecursiveAbsolute(SaveDirectory);
		LoadAllData();

		if (!FilesExist())
			SaveAllData();

		GD.Print("SaveNode is ready. MetaData, RunData, and SettingsData have been initialized.");
	}

	public void SaveData(SaveResource data, FileType type)
	{
		var filePath = GetSavePath(type);
		var error = ResourceSaver.Save(data, filePath);
		if (error != Error.Ok)
		{
			GD.PrintErr($"Failed to save data to {filePath}: {error}");
		}
		else
		{	
			GD.Print($"Data successfully saved to {filePath}");
		}
	}

	public Resource LoadData(FileType type)
	{
		var filePath = GetSavePath(type);

		// check if the file exists before trying to load it
		if (!FileAccess.FileExists(filePath))
		{
			GD.Print($"No existing data found at {filePath}. A new instance will be created.");
			return null;
		}

		var resource = ResourceLoader.Load(filePath);
		if (resource == null) {
			GD.PrintErr($"Failed to load data from {filePath}");
			return null;
		}

		
		GD.Print($"Data successfully loaded from {filePath}");
		return resource;
		
	}

	public void DeleteData(FileType type)
	{
		var filePath = GetSavePath(type);
		if (!FileAccess.FileExists(filePath)) {
			GD.Print($"No data found at {filePath} to delete.");
			return;
		}

		// Attempt to delete the file and log the result
		var error = DirAccess.RemoveAbsolute(filePath);
		GD.Print(error == Error.Ok
			? $"Data successfully deleted at {filePath}"
			: $"Failed to delete data at {filePath}: {error}");

	}

	public void DeleteMetaData() => DeleteData(FileType.Meta);
	public void DeleteRunData() => DeleteData(FileType.Run);
	public void DeleteSettingsData() => DeleteData(FileType.Settings);
	public bool FileExists(FileType type) => FileAccess.FileExists(GetSavePath(type));
	public bool MetaDataExists() => FileExists(FileType.Meta);
	public bool RunDataExists() => FileExists(FileType.Run);
	public bool SettingsDataExists() => FileExists(FileType.Settings);

	public void DeleteAllData()
	{
		DeleteData(FileType.Meta);
		DeleteData(FileType.Run);
		DeleteData(FileType.Settings);
	}

	public void SaveAllData()
	{
		SaveData(MetaData, FileType.Meta);
		SaveData(RunData, FileType.Run);
		SaveData(SettingsData, FileType.Settings);
	}

	public void LoadAllData()
	{
		MetaData = LoadData(FileType.Meta) as MetaData ?? DefaultMetaData;
		RunData = LoadData(FileType.Run) as RunData ?? DefaultRunData;
		SettingsData = LoadData(FileType.Settings) as SettingsData ?? DefaultSettingsData;

		if (MetaData.IsFirstTimePlayer)
		{
			RunData.IsTutorialGameplay = true;
			GD.Print("First time player detected. Tutorial gameplay enabled.");
		}

		GD.Print(MetaData.ToString());
		GD.Print(RunData.ToString());
		GD.Print(SettingsData.ToString());
	}

	public static string GetSavePath(FileType type) => $"user://saves/{type.ToString().ToLower()}_data.tres";

	private bool FilesExist()
	{
		return FileAccess.FileExists(GetSavePath(FileType.Meta)) &&
			   FileAccess.FileExists(GetSavePath(FileType.Run)) &&
			   FileAccess.FileExists(GetSavePath(FileType.Settings));
	}
}
