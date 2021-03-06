﻿using GuardTourSystem.Database.Model;
using GuardTourSystem.Model;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardTourSystem.ViewModel.Query.ChartViewModel
{
    class WorkerBarViewModel : BindableBase
    {
        public List<CountInfo> CountInfos { get; set; }

        public List<string> Workers { get; set; }
        private string selectWorker;
        public string SelectWorker
        {
            get { return selectWorker; }
            set
            {
                SetProperty(ref this.selectWorker, value);
                InitPie(SelectWorker);
            }
        }

        public ObservableCollection<AssetData> Data { get; set; }


        public WorkerBarViewModel(List<CountInfo> workerCountInfo)
        {
            CountInfos = workerCountInfo;
            InitData();
        }

        private void InitData()
        {
            this.Workers = new List<string>();
            this.Data = new ObservableCollection<AssetData>();

            foreach (var countInfo in CountInfos)
            {
                Workers.Add(countInfo.CountName);
            }
            if (CountInfos.Count != 0)
            {
                SelectWorker = Workers[0];
            }
        }

        private void InitPie(string selectWorker)
        {
            var targetCountInfo = CountInfos.Find(info => info.CountName.Equals(selectWorker));
            Data.Clear();
            Data.Add(new AssetData(true) { Value = targetCountInfo.PatrolCount, Label = "打卡次数" });
            Data.Add(new AssetData(false) { Value = targetCountInfo.MissCount, Label = "漏打次数" });
        }
    }
}
