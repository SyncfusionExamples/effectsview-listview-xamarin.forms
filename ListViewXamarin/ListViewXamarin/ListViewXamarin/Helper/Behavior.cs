using Syncfusion.XForms.EffectsView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<SfEffectsView>
    {
        protected override void OnAttachedTo(SfEffectsView bindable)
        {
            bindable.SelectionChanged += Bindable_SelectionChanged;
            base.OnAttachedTo(bindable);
        }

        private void Bindable_SelectionChanged(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var effectsView = sender as SfEffectsView;
                effectsView.ScaleFactor = 0.85;
                effectsView.ApplyEffects(SfEffects.Scale);
            });
        }
        protected override void OnDetachingFrom(SfEffectsView bindable)
        {
            bindable.SelectionChanged -= Bindable_SelectionChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
