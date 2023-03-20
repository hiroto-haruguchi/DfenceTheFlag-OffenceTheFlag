using Assets.Scripts.Manager;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class SelectViewerManager : MonoBehaviour
    {
        //�\�����郆�j�b�g/�u���b�N�̐�
        public static int selectViewNum = 4;

        public viewMode currentViewer = viewMode.Unit;

        //���\�����Ă���ꏊ�������C�e���[�^
        private int UnitListIt = 1;
        private int BlockListIt = 1;

        //�\�����Ă���u���b�N
        private UnitKindIs[] PreviousUnitView = new UnitKindIs[selectViewNum];
        private BlockKindIs[] PreviousBlockView = new BlockKindIs[selectViewNum];

        //Viewer�ɑ΂���X�V�C�x���g
        //�eUnitViewer�Ɍ��݂̒S����m�点��
        public IObservable<UnitKindIs[]> updateResponsibleUnitView { get { return UpdateResponsibleUnitView; } }
        private Subject<UnitKindIs[]> UpdateResponsibleUnitView = new Subject<UnitKindIs[]>();

        //�eBlockViewewr�Ɍ��݂̒S����m�点��
        public IObservable<BlockKindIs[]> updateResponsibleBlockView { get { return UpdateResponsibleBlockView; } }
        private Subject<BlockKindIs[]> UpdateResponsibleBlockView = new Subject<BlockKindIs[]>();


        public void UpdateUnitViewer(UpdateDirection d)
        {
            if (UnitListIt + (selectViewNum * (int)d) >= Enum.GetNames(typeof(UnitKindIs)).Length)
            {
                UnitListIt = 1;
            }else if(UnitListIt + (selectViewNum * (int)d) <= 0)
            {
                UnitListIt = (int)Enum.GetNames(typeof(UnitKindIs)).Length- (((int)Enum.GetNames(typeof(UnitKindIs)).Length-1) % selectViewNum);
            }
            else
            {
                UnitListIt += (int)d * selectViewNum;
            }

            int i;
            for (i = 0; i < selectViewNum; i++)
            {
                if (UnitListIt + i >= Enum.GetNames(typeof(UnitKindIs)).Length)
                {
                    PreviousUnitView[i] = UnitKindIs.Nobody;
                }
                else
                {
                    PreviousUnitView[i] = (UnitKindIs)((int)UnitListIt + i);

                }
            }

            UpdateResponsibleUnitView.OnNext(PreviousUnitView);

        }

        public void UpdateBlockViewer(UpdateDirection d)
        {

            if (BlockListIt + (selectViewNum * (int)d) >= Enum.GetNames(typeof(BlockKindIs)).Length)
            {
                

                BlockListIt = 1;
            }
            else if (BlockListIt + (selectViewNum * (int)d) <= 0)
            {
                BlockListIt = (int)Enum.GetNames(typeof(BlockKindIs)).Length - (((int)Enum.GetNames(typeof(BlockKindIs)).Length - 1) % selectViewNum);
            }
            else
            {
                BlockListIt +=selectViewNum*(int)d;
            }

            for (int i = 0; i < selectViewNum; i++)
            {
                if (BlockListIt + i >= Enum.GetNames(typeof(BlockKindIs)).Length)
                {
                    PreviousBlockView[i] = BlockKindIs.Nobody;
                }
                else
                {
                    PreviousBlockView[i] = (BlockKindIs)(BlockListIt + i);

                }
            }

            UpdateResponsibleBlockView.OnNext(PreviousBlockView);

        }

        public enum UpdateDirection
        {
            Forward = 1,
            Backward = -1,
            Initialize=0
        }

        public enum viewMode
        {
            Unit,
            Block
        }
    }


}