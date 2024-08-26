using BT_COMMONS.Operators.PermissionAttributes;
using BT_COMMONS.Transactions.TenderAttributes;

namespace BT_COMMONS.Operators;

public enum OperatorBoolPermission
{
    [PermissionPromptName("POS Access")]
    POS_Access = 0,

    [PermissionPromptName("Returns")]
    POS_Return_Access = 10,
    [PermissionPromptName("Return without Receipt")]
    POS_Return_NoInform = 11,

    [PermissionPromptName("Hotshot")]
    POS_Hotshot_Access = 20,

    [PermissionPromptName("Item Void")]
    POS_ItemMod_ItemVoid = 30,

    [PermissionPromptName("Transaction Void")]
    POS_TransMod_TransVoid = 40,

    [PermissionPromptName("Open Register")]
    POS_Admin_RegManagement_OpenRegister = 90,
    [PermissionPromptName("Close Register")]
    POS_Admin_RegManagement_CloseRegister = 91,
    [PermissionPromptName("X Read")]
    POS_Admin_RegManagement_XRead = 92,
    [PermissionPromptName("Training Mode")]
    POS_Admin_RegManagement_Training = 93,

    [PermissionPromptName("Loan / Declare Opening Float")]
    POS_Admin_CashManagement_Loan = 94,
    [PermissionPromptName("Cash Pickup")]
    POS_Admin_CashManagement_Pickup = 95,
    [PermissionPromptName("Cash Spot Check")]
    POS_Admin_CashManagement_Spotcheck = 96,
    [PermissionPromptName("Petty Cash In")]
    POS_Admin_CashManagement_PettyIn = 97,
    [PermissionPromptName("Petty Cash Out")]
    POS_Admin_CashManagement_PettyOut = 98,
    [PermissionPromptName("No Sale")]
    POS_Admin_CashManagement_NoSale = 99,

    [PermissionPromptName("Receipt Reprint")]
    POS_Admin_TrxnManagement_ReceiptReprint = 100,
    [PermissionPromptName("Postvoid")]
    POS_Admin_TrxnManagement_PostVoid = 101,


    BO_Access = 1000
}
