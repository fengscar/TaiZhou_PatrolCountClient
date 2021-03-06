﻿using GuardTourSystem.Database.BLL;
using GuardTourSystem.Services;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardTourSystem.ViewModel.Popup
{
    class SystemInitViewModel : AbstractPopupNotificationViewModel
    {
        //删除逻辑如下
        //1.如果删除地点: !必须! 附带删除班次和计划
        //2.如果删除班次: !必须! 附带删除计划

        private bool initPlace;
        public bool InitPlace
        {
            get { return initPlace; }
            set
            {
                //if (value)
                //{
                //    InitFrequence = true;
                //    InitPlan = true;
                //}
                initPlace = value;
                CConfirm.RaiseCanExecuteChanged();
                RaisePropertyChanged("InitPlace");
                //SetProperty(ref this.initPlace, value);
            }
        }

        private bool initData;
        public bool InitData
        {
            get { return initData; }
            set
            {
                CConfirm.RaiseCanExecuteChanged();
                initData = value;
                RaisePropertyChanged("InitData");
            }
        }



        public SystemInitViewModel()
        {
            Title = "系统初始化";
            ConfirmButtonText = "开始";
            CConfirm = new DelegateCommand(ReInit,
                () => { return  InitPlace || InitData; });
                 //() => { return InitPlan || InitPlace || InitFrequence || InitWorker || InitEvent || InitData; });
        }

        public async void ReInit()
        {
            Finish();
            //弹出确认框,让用户点击确定
            var confirmMessage = new StringBuilder("将初始化以下数据:\n");
            int index = 1;
            if (InitPlace)
            {
                confirmMessage.Append(index + ". 人员信息\n");
                index++;
            }
            //if (InitFrequence)
            //{
            //    confirmMessage.Append(index + ". 班次信息\n");
            //    index++;
            //}
            //if (InitPlan)
            //{
            //    confirmMessage.Append(index + ". 计数计划\n");
            //    index++;
            //}
            //if (InitWorker)
            //{
            //    confirmMessage.Append(index + ". 管理卡信息\n");
            //    index++;
            //}
            //if (InitEvent)
            //{
            //    confirmMessage.Append(index + ". 事件信息\n");
            //    index++;
            //}
            if (InitData)
            {
                confirmMessage.Append(index + ". 打卡记录\n");
                index++;
            }
            confirmMessage.Append("该操作无法撤销!");

            var result = await ShowConfirmDialog("确定要进行系统初始化吗?", confirmMessage.ToString());
            if (result == MessageDialogResult.Negative) //用户取消
            {
                return;
            }
            else
            {
                if (InitPlace)
                {
                    new RouteBLL().Init();
                    new PlaceBLL().Init();
                }
                //if (InitFrequence)
                //{
                //    new FrequenceBLL().Init();
                //}
                //if (InitPlan)
                //{
                //    new DutyBLL().Init();
                //}
                //if (InitWorker)
                //{
                //    new WorkerBLL().Init();
                //}
                //if (InitEvent)
                //{
                //    new EventBLL().Init();
                //}
                if (InitData)
                {
                    new RawDataBLL().Init();
                }
                AppStatusViewModel.Instance.ShowInfo("系统初始化成功", 5);

                //重新生成当天考核表
                //string error = null;
                //new DutyBLL().GenerateDuty(out error, null, DateTime.Now);
            }
        }
    }
}
