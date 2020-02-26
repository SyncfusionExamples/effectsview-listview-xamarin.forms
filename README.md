# How to use effects view in ListView (SfListView) Xamarin.Forms ?
You can integrate the SfEffects in Xamarin.forms SfListView by loading the SfEffectsView as the content of ItemTemplate or SelectedItemTemplate.

**Xaml:** SfEffectsView added as the content of SelectedItemplate with Scale and Selection effects.
```xml
<sync:SfListView x:Name="listView"
                AutoFitMode="Height" 
                SelectionMode="Single"
                ItemsSource="{Binding BookInfo}">
    <sync:SfListView.SelectedItemTemplate>
        <DataTemplate>
            <Grid>
                <effects:SfEffectsView x:Name="effectsView"
                                       SelectionColor="LightSeaGreen"
                                       FadeOutRipple="True"
                                       RippleAnimationDuration="1000"
                                       IsSelected="True">
                    <effects:SfEffectsView.Behaviors>
                        <local:Behavior/>
                    </effects:SfEffectsView.Behaviors>
                    <StackLayout>
                        <Label Text="{Binding BookName}" FontSize="21"
                               FontAttributes="Bold"/>
                        <Label Grid.Row="1" Text="{Binding BookDescription}"
                               FontSize="15"/>
                    </StackLayout>
                </effects:SfEffectsView>
            </Grid>
        </DataTemplate>
    </sync:SfListView.SelectedItemTemplate>
</sync:SfListView>
```
**C#:** Programmatically apply effects to the SelectedItem.
``` C#
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
```
