using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PermissionsScript : MonoBehaviour
{
    private IEnumerator AskForPermissions()
    {
    #if UNITY_ANDROID
        List<bool> permissions = new List<bool>() { false, false, false, false };
        List<bool> permissionsAsked = new List<bool>() { false, false, false, false };
        List<Action> actions = new List<Action>()
        {
            new Action(() => {
                permissions[2] = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite);
                if (!permissions[2] && !permissionsAsked[2])
                {
                    Permission.RequestUserPermission(Permission.ExternalStorageWrite);
                    permissionsAsked[2] = true;
                    return;
                }
            }),
            new Action(() => {
                permissions[3] = Permission.HasUserAuthorizedPermission("android.permission.READ_PHONE_STATE");
                if (!permissions[3] && !permissionsAsked[3])
                {
                    Permission.RequestUserPermission("android.permission.READ_PHONE_STATE");
                    permissionsAsked[3] = true;
                    return;
                }
            })
        };
        for(int i = 0; i < permissionsAsked.Count; )
        {
            actions[i].Invoke();
            if(permissions[i])
            {
                ++i;
            }
            yield return new WaitForEndOfFrame();
        }
    #endif
    }
}
