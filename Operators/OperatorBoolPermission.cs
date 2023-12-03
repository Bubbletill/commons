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

    [PermissionPromptName("Item Void")]
    POS_ItemMod_ItemVoid = 30,

    [PermissionPromptName("Transaction Void")]
    POS_TransMod_TransVoid = 40,

    [PermissionPromptName("Open Register")]
    POS_Admin_OpenRegister = 90,
    [PermissionPromptName("Close Register")]
    POS_Admin_CloseRegister = 91,

    [PermissionPromptName("Loan / Declare Opening Float")]
    POS_Admin_CashManagement_Loan = 92,
    [PermissionPromptName("Cash Pickup")]
    POS_Admin_CashManagement_Pickup = 93,
    [PermissionPromptName("Cash Spot Check")]
    POS_Admin_CashManagement_Spotcheck = 94,
    [PermissionPromptName("Petty Cash In")]
    POS_Admin_CashManagement_PettyIn = 95,
    [PermissionPromptName("Petty Cash Out")]
    POS_Admin_CashManagement_PettyOut = 96,

    [PermissionPromptName("Receipt Reprint")]
    POS_Admin_ReceiptReprint = 97,
    [PermissionPromptName("Postvoid")]
    POS_Admin_PostVoid = 98,
    [PermissionPromptName("No Sale")]
    POS_Admin_NoSale = 99,
    [PermissionPromptName("Training Mode")]
    POS_Admin_Training = 100,
    [PermissionPromptName("X Read")]
    POS_Admin_XRead = 101,


    BO_Access = 1000
}
