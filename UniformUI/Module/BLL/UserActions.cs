using System;
using System.Collections.Generic;
using HalconDotNet;
using System.Windows.Forms;
using UniformUI.Frm;

namespace UniformUI.Frm
{
  /// <summary>
  /// This is the place where the user adds his/her code called from the draw
  /// object callbacks.
  /// </summary>
  class UserActions
  {
      private Frm_Setting halcon_dialog;

      public UserActions(Frm_Setting hd)
    {
      halcon_dialog = hd;
    }

    public void SobelFilter(HDrawingObject dobj, HWindow hwin,string type)
    {
      try
      {
        HImage image = halcon_dialog.BackgroundImage;
        HRegion region = new HRegion(dobj.GetDrawingObjectIconic());
        halcon_dialog.AddToStack(image.ReduceDomain(region).SobelAmp("sum_abs", 11));
        halcon_dialog.DisplayResults();
      }
      catch (HalconException hex)
      {
        MessageBox.Show(hex.GetErrorMessage(), "HALCON error", MessageBoxButtons.OK);
      }
    }
  }
}
