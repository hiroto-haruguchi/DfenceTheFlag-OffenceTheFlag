using Assets.Scripts.Manager;
using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProvider : MonoBehaviour
{
    [SerializeField]
    private GameObject ___Block1;

    [SerializeField]
    private GameObject ___Block2;

    [SerializeField]
    private GameObject ___Block3;

    [SerializeField]
    private GameObject ___Block4;

    [SerializeField]
    private GameObject ___Block5;

    private GameObject BlockObject;

    public GameObject createBlock(BlockRegistrationInfo info)
    {
        BlockObject = GetBlock(info.iAm);
        return BlockObject;
    }

    private GameObject GetBlock(BlockKindIs kind)
    {
        var unit = Instantiate(SelectBlock(kind));
        return unit;

    }
    private GameObject SelectBlock(BlockKindIs kind)
    {
        GameObject blockObj = null;

        switch (kind)
        {
            case BlockKindIs.Nobody:
                return blockObj;
            case BlockKindIs.Block1:
                blockObj = ___Block1;
                return blockObj;
            case BlockKindIs.Block2:
                blockObj = ___Block2;
                return blockObj;
            case BlockKindIs.Block3:
                blockObj = ___Block3;
                return blockObj;
            case BlockKindIs.Block4:
                blockObj = ___Block4;
                return blockObj;
            case BlockKindIs.Block5:
                blockObj = ___Block5;
                return blockObj;
            default:
                return blockObj;
        }

    }

}
