using Godot;
using Godot.Collections;
using MyTypes;

[GlobalClass]
public partial class ItemDepencency : Resource
{
	[Export] public Array<Dependency> Dependencies { get; set; } = new();

	public void AddDependency(Dependency dependency)
	{
		Dependencies.Add(dependency);
	}
	
	public static bool CanExecute(Array<Dependency> dependencies, AmmoType? ammoType, int? mana)
	{
		foreach (var dependency in dependencies)
		{
			if (dependency is DependencyAmmo ammoDependency)
			{
				if (ammoType == null || ammoDependency.AmmoType != ammoType)
					return false;
			}
			else if (dependency is DependencyMana manaDependency)
			{
				if (mana == null || manaDependency.Cost > mana)
					return false;
			}
		}

		return true;
	}
}
