using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Thirdweb;
using UnityEngine.UI;
using TMPro;
using System;

public class ConnectWallet : MonoBehaviour
{
    public string Address { get; private set; }

    string NFTAddressSmartContract = "0x898C4367D0Ab747c4cC607fc2cD9E60Fe3cEA0D6";

    public Button nftButton;
    public TextMeshProUGUI nftClaimingStatusText;

    private void Start()
    {
        nftButton.gameObject.SetActive(false);
        nftClaimingStatusText.gameObject.SetActive(false);
    }

    public void ConnectWalletResetAll()
    {
        ResourceBoost.Instance.people = 0;
        ResourceBoost.Instance.process = 0;
        ResourceBoost.Instance.business = 0;
    }

    public async void ClaimNFTPass()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        nftClaimingStatusText.text = "Registering...";
        nftClaimingStatusText.gameObject.SetActive(true);
        nftButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(NFTAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            nftClaimingStatusText.text = "Test Registered!";
            nftButton.gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while claiming the NFT: {ex.Message}");
            // Optionally, update the UI to inform the user of the error
            nftClaimingStatusText.text = "Failed to register. Please try again.";
            nftButton.interactable = true;
        }
    }
}
