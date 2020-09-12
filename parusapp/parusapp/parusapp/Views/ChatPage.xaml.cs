using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using parusapp.ViewModels;
using Xamarin.Forms;

namespace parusapp.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            this.BindingContext = new ChatPageViewModel();

        }

        public void ScrollTap(object sender, System.EventArgs e)
        {
            //lock (new object())
            //{
            //    if (bindingcontext != null)
            //    {
            //        var vm = bindingcontext as chatpageviewmodel;

            //        device.begininvokeonmainthread(() =>
            //        {
            //            while (vm.delayedmessages.count > 0)
            //            {
            //                vm.messages.insert(0, vm.delayedmessages.dequeue());
            //            }
            //            vm.showscrolltap = false;
            //            vm.lastmessagevisible = true;
            //            vm.pendingmessagecount = 0;
            //            chatlist?.scrolltofirst();
            //        });


            //    }

            //}
        }

        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }
    }
}
