using BT_COMMONS.Operators.PermissionAttributes;
using BT_COMMONS.Transactions.TenderAttributes;

namespace BT_COMMONS.Operators;

public enum OperatorBoolPermission
{
    [PermissionPromptName("POS Access")]
    POS_Access = 0,

    [PermissionPromptName("Returns")]
    POS_Return_Access = 10,

    [PermissionPromptName("Hotshot")]
    POS_Hotshot_Access = 20,

    [PermissionPromptName("Item Modifications")]
    POS_ItemMod_Access = 30,
    [PermissionPromptName("Item Void")]
    POS_ItemMod_ItemVoid = 31,

    [PermissionPromptName("Transaction Modifications")]
    POS_TransMod_Access = 40,
    [PermissionPromptName("Transaction Void")]
    POS_TransMod_TransVoid = 41,

    [PermissionPromptName("Open Register")]
    POS_Admin_OpenRegister = 90,
    [PermissionPromptName("Close Register")]
    POS_Admin_CloseRegister = 91,
    [PermissionPromptName("Lone / Declare Opening Float")]
    POS_Admin_Lone = 92,

    BO_Access = 1000
}
