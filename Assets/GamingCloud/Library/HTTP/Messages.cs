using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gamingCloud
{
    public enum RestfulMessages
    {
        successful = 0,
        failure = -1,
        AccessDenied = -1100,
        tableNotFound = 200,
        achiveIdNotFound = 300,
        ExtraIsExist = 150,
        systemError = -500,
        playerisBan = -750,
        NoPasswordInBody = -751,
        usernameFieldNotExists = 10010,
        passwordFieldNotExist = 10011,
        usernameExists = 10012,
        phoneNumberExists = 10013,
        emailExists = 10014,
        playerStorageExist = 10050,
        playerStorageKeyNotFound = 10051,
        usernameNotFound = 404,
        SenderNotFound = 10070,
        EmailOrPhoneNotFound = 10073,
        EmailwalletNotEnough = 10078,
        SMSwalletNotEnough = 10079,
        loginLimit = 10090,
        yourDeviceIdLoggedIn = 10091,
        SchemaIdNotFound = 4043,
        NoAnyRow = 4011,

    }

    public enum sortMode
    {
        Asc = 1,
        Desc = -1,
    }
    public enum SenderMode
    {
        sms = 0,
        email = 1,
    }
    public enum CodeType
    {
        numeric = 0,
        alphabet = 1,
    }

    public enum AchivementMode
    {
        undone = 0,
        done = 1,
        full = 2

    }

}
