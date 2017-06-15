﻿using GuardTourSystem.Database.BLL;
using GuardTourSystem.Model;
using GuardTourSystem.Utils;
using GuardTourSystem.View;
using GuardTourSystem.ViewModel.DataManage;
using GuardTourSystem.ViewModel.Popup;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuardTourSystem.ViewModel
{
    public enum PopupEnum
    {
        Reanalysis, // 重新分析
        ClearPatrolData, ImportPatrolData, ExportPatrolData, //巡检数据的清理,导入,导出
        SystemInit, ManageUser, ChangePassword, //系统初始化
        Language,//选择语言
        DeviceTest,//巡检机管理
        Help, HowToStart, AboutUs, //帮助, 关于我们.
        Error, //系统崩溃错误信息
    }
    public enum ViewEnum
    {
        //数据查询菜单
        ReadPatrol, QueryRawData, ReadHit, QueryResult, QueryChart,
        //信息录入         
        SetRoute, SetWorker, SetEvent, SetFrequence, SetRegular, SetIrregular,
        //数据维护             
        DataManage,
        //系统管理  
        SystemLog,
        //系统帮助
        HowToStart,
        //测试
        Test
    }
    public class AppContentViewModel : BindableBase
    {
        #region 单例模式
        private static AppContentViewModel instance { get; set; }
        public static AppContentViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppContentViewModel();
                }
                return instance;
            }
            private set { }
        }
        #endregion

        #region 弹窗请求(交互请求)
        public InteractionRequest<INotification> PopupReanalysis { get; private set; }
        public InteractionRequest<INotification> PopupClearPatrol { get; private set; }
        public InteractionRequest<INotification> PopupSystemInit { get; private set; }
        public InteractionRequest<INotification> PopupManageUser { get; private set; }
        public InteractionRequest<INotification> PopupChangePassword { get; private set; }
        public InteractionRequest<INotification> PopupLanguage { get; private set; }
        public InteractionRequest<INotification> PopupDeviceTest { get; private set; }
        public InteractionRequest<INotification> PopupAboutUs { get; private set; }
        public InteractionRequest<INotification> PopupError { get; private set; }
        public InteractionRequest<INotification> PopupSharePatrol { get; private set; }
        #endregion


        private const string BACKGROUND_IMAGE_PATH = "/Resource/Img/Background.jpg";
        /// <summary>
        /// 当前界面没有内容显示时, 显示预设的背景图片
        /// </summary>
        private string backgroundImgPath;
        public string BackgroundImgPath
        {
            get { return backgroundImgPath; }
            set
            {
                SetProperty(ref this.backgroundImgPath, value);
            }
        }

        /// <summary>
        /// 当前界面所显示的内容
        /// </summary>
        private UserControl content;
        public UserControl Content
        {
            get { return content; }
            set
            {
                SetProperty(ref this.content, value);
                if (value == null) //如果没有内容,显示背景图片,否则隐藏背景图片
                {
                    BackgroundImgPath = BACKGROUND_IMAGE_PATH;
                }
                else
                {
                    BackgroundImgPath = null;
                }
            }
        }


        //InteractionRequest 必须提前初始化, 否则不能弹窗??
        private AppContentViewModel()
        {
            this.Content = null;

            this.PopupReanalysis = new InteractionRequest<INotification>();
            this.PopupClearPatrol = new InteractionRequest<INotification>();
            this.PopupSystemInit = new InteractionRequest<INotification>();
            this.PopupManageUser = new InteractionRequest<INotification>();
            this.PopupChangePassword = new InteractionRequest<INotification>();
            this.PopupLanguage = new InteractionRequest<INotification>();
            this.PopupDeviceTest = new InteractionRequest<INotification>();
            this.PopupAboutUs = new InteractionRequest<INotification>();
            this.PopupError = new InteractionRequest<INotification>();
            this.PopupSharePatrol = new InteractionRequest<INotification>();
        }

        /// <summary>
        /// 弹出窗口
        /// </summary>
        /// <param name="pe"></param>
        /// <param name="param"></param>
        public void PopupWindow(PopupEnum pe, object param = null)
        {
            this.Content = null;//关闭当前内容
            MainWindowViewModel.Instance.ContentName = pe.GetContentName();
            switch (pe)
            {
                case PopupEnum.Reanalysis:
                    this.PopupReanalysis.Raise(new ReanalysisViewModel());
                    break;

                case PopupEnum.ClearPatrolData:
                    this.PopupClearPatrol.Raise(new ClearPatrolDataViewModel());
                    break;

                case PopupEnum.ImportPatrolData:
                    string importError;
                    if (new ImportExportPatrolDataViewModel().Import(out importError))
                    {
                        AppStatusViewModel.Instance.ShowInfo("巡检数据导入成功");
                    }
                    else if (importError != null) //用户取消操作则error为null,不进行提示
                    {
                        AppStatusViewModel.Instance.ShowError("巡检数据导入失败  " + importError);
                    }

                    break;

                case PopupEnum.ExportPatrolData:
                    string exportError;
                    if (new ImportExportPatrolDataViewModel().Export(out exportError))
                    {
                        AppStatusViewModel.Instance.ShowInfo("巡检数据导出成功");
                    }
                    else if (exportError != null) //用户取消操作则error为null,不进行提示
                    {
                        AppStatusViewModel.Instance.ShowError("巡检数据导出失败  " + exportError);
                    }

                    break;

                case PopupEnum.SystemInit:
                    this.PopupSystemInit.Raise(new SystemInitViewModel());
                    break;

                case PopupEnum.ManageUser:
                    this.PopupManageUser.Raise(new UserManageViewModel());
                    break;
                case PopupEnum.ChangePassword:
                    this.PopupChangePassword.Raise(new ModifyPasswordViewModel());
                    break;

                case PopupEnum.Language:
                    this.PopupLanguage.Raise(new LanguageViewModel());
                    break;

                case PopupEnum.DeviceTest:
                    this.PopupDeviceTest.Raise(new DeviceTestViewModel());
                    break;


                case PopupEnum.Help:
                    if (!ChmHelper.OpenHelp())
                    {
                        AppStatusViewModel.Instance.ShowError("未能打开帮助,文件已丢失");
                    };
                    break;

                case PopupEnum.HowToStart:
                    if (!ChmHelper.OpenHelp(""))
                    {
                        AppStatusViewModel.Instance.ShowError("未能打开帮助,文件已丢失");
                    };
                    break;

                case PopupEnum.AboutUs:
                    this.PopupAboutUs.Raise(new AboutUsViewModel());
                    break;

                case PopupEnum.Error:
                    string errorInfo = "NULL";
                    if (param != null)
                    {
                        errorInfo = (string)param;
                    }
                    this.PopupError.Raise(new AppErrorViewModel(errorInfo));
                    break;

                default:
                    break;
            }
            MainWindowViewModel.Instance.ContentName = null;
        }


        #region 切换显示内容
        /// <summary>
        /// 在APP当前CONTENT区域显示指定内容
        /// </summary>
        /// <param name="contentEnum"></param>
        public void ShowView(ViewEnum contentEnum)
        {
            if (this.Content != null && contentEnum.GetContentName().Equals(MainWindowViewModel.Instance.ContentName))
            {
                return;
            }
            var view = GetView(contentEnum);
            if (view != null)
            {
                this.Content = view;
                MainWindowViewModel.Instance.ContentName = contentEnum.GetContentName();
            }
            else
            {
                MainWindowViewModel.Instance.ContentName = null;
            }
        }
        /// <summary>
        /// 关闭APP当前CONTENT区域所显示的内容
        /// </summary>
        public void CloseView()
        {
            this.Content = null;
            MainWindowViewModel.Instance.ContentName = null;
        }

        /// <summary>
        /// 获取指定的View
        /// </summary>
        /// <param name="contentEnum"></param>
        /// <returns></returns>
        private ShowContentView GetView(ViewEnum contentEnum)
        {
            switch (contentEnum)
            {
                case ViewEnum.ReadPatrol:
                    return new ReadPatrolView();
                case ViewEnum.QueryRawData:
                    return new QueryRawDataView();
                case ViewEnum.ReadHit:
                    return new ReadHitView();
                case ViewEnum.QueryResult:
                    return new QueryResultView();
                case ViewEnum.QueryChart:
                    return new QueryChartView();
                case ViewEnum.SetRoute:
                    return new RouteView();
                case ViewEnum.SetWorker:
                    return new WorkerView();
                case ViewEnum.SetEvent:
                    return new EventView();
                case ViewEnum.SetFrequence:
                    return new FrequenceView();
                case ViewEnum.SetRegular:
                    return new RegularView();
                case ViewEnum.SetIrregular:
                    return new IrregularView();
                case ViewEnum.DataManage:
                    return new DataManageView();
                default:
                    return null;
            }
        }
        #endregion
    }
}
