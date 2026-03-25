using Godot;
using SaveData;

public partial class SettingsSave : Control
{
	[Export] public Button ClearRunButton { get; set; }
	[Export] public Button ClearMetaButton { get; set; }
	[Export] public Button ClearSettingsButton { get; set; }
	[Export] public Button DeleteAllButton { get; set; }
	private SaveNode SaveNode => GetNode<SaveNode>("/root/SaveNode");

	public override void _Ready()
	{
		if (ClearRunButton == null || ClearMetaButton == null || ClearSettingsButton == null || DeleteAllButton == null || SaveNode == null)
		{
			GD.PrintErr("ClearRunButton, ClearMetaButton, ClearSettingsButton, and DeleteAllButton must be assigned in the editor. AND SaveNode must be present in the scene tree.");
			return;
		}

		UpdateButtonVisibility();
		ClearRunButton.Pressed += ClearRunData;
		ClearMetaButton.Pressed += ClearMetaData;
		ClearSettingsButton.Pressed += ClearSettingsData;
		DeleteAllButton.Pressed += DeleteAllData;
	}

	private void ClearRunData()
	{
		SaveNode.DeleteData(FileType.Run);
		ResetOnDeletion();
	}

	private void ClearMetaData()
	{
		SaveNode.DeleteData(FileType.Meta);
		SaveNode.DeleteData(FileType.Run);
		ResetOnDeletion();
	}

	private void ClearSettingsData()
	{
		SaveNode.DeleteData(FileType.Settings);
		ResetOnDeletion();
	}

	private void DeleteAllData()
	{
		SaveNode.DeleteAllData();
		ResetOnDeletion();
	}

	private void ResetOnDeletion()
	{
		SaveNode.ExecuteReady();
		GetTree().ReloadCurrentScene();
	}

	private void UpdateButtonVisibility()
	{
		ClearRunButton.Visible = SaveNode.RunDataExists();
		ClearMetaButton.Visible = SaveNode.MetaDataExists();
		ClearSettingsButton.Visible = SaveNode.SettingsDataExists();
		DeleteAllButton.Visible = ClearRunButton.Visible || ClearMetaButton.Visible || ClearSettingsButton.Visible;
	}
}
