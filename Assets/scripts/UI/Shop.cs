using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using Debug = UnityEngine.Debug;
public class Shop : MonoBehaviour
{
    public void SelectWaterTurret()
    {
        Builder.instance.setTurretToBuild(Builder.instance.waterTurretPrefab);
        Builder.instance.setCurrentPrice(1000);
    }
    public void SelectFireTurret()
    {
        Builder.instance.setTurretToBuild(Builder.instance.fireTurretPrefab);
        Builder.instance.setCurrentPrice(3000);
    }
    public void SelectIceTurret()
    {
        Builder.instance.setTurretToBuild(Builder.instance.iceTurretPrefab);
        Builder.instance.setCurrentPrice(2000);
    }
}
