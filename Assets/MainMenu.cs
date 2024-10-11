using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Thirdweb;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    public string Address { get; private set; }

    string certificateAddressSmartContract = "0x0CC9204d80d6f9eB87A2d8527b7E09630Fb28ff1";

    public Button certificateButton;
    public TextMeshProUGUI claimingStatus;
    public TextMeshProUGUI statusProcess;
    public TextMeshProUGUI statusPeople;
    public TextMeshProUGUI statusBusinessEnvironment;

    public Button peopleButton;
    public Button processButton;
    public Button businessEnvironmentButton;


    private void Start()
    {
        certificateButton.gameObject.SetActive(false);
        claimingStatus.gameObject.SetActive(false);
        statusProcess.gameObject.SetActive(false);
        statusPeople.gameObject.SetActive(false);
        statusBusinessEnvironment.gameObject.SetActive(false);
        UpdateTestStatus();
    }

    private void UpdateTestStatus() {
        if (ResourceBoost.Instance.people == 1)
        {
            statusPeople.text = "Pass";

            // Đặt màu của text thành 00FF14
            statusPeople.color = new Color32(0, 255, 20, 255);

            statusPeople.gameObject.SetActive(true);
            peopleButton.interactable = false;
        }
        else if (ResourceBoost.Instance.people == 2)
        {
            statusPeople.text = "Fail";

            // Đặt màu của text thành FF000B
            statusPeople.color = new Color32(255, 0, 11, 255);

            statusPeople.gameObject.SetActive(true);
            peopleButton.interactable = false;
            claimingStatus.text = "You Failed the Test";

            // Đặt màu của text thành FF000B
            claimingStatus.color = new Color32(255, 0, 11, 255);

            claimingStatus.gameObject.SetActive(true);
        }

        if (ResourceBoost.Instance.process == 1)
        {
            statusProcess.text = "Pass";

            // Đặt màu của text thành 00FF14
            statusProcess.color = new Color32(0, 255, 20, 255);

            statusProcess.gameObject.SetActive(true);
            processButton.interactable = false;
        }
        else if (ResourceBoost.Instance.process == 2)
        {
            statusProcess.text = "Fail";

            // Đặt màu của text thành FF000B
            statusProcess.color = new Color32(255, 0, 11, 255);

            statusProcess.gameObject.SetActive(true);
            processButton.interactable = false;
            claimingStatus.text = "You Failed the Test";

            // Đặt màu của text thành FF000B
            claimingStatus.color = new Color32(255, 0, 11, 255);

            claimingStatus.gameObject.SetActive(true);
        }

        if (ResourceBoost.Instance.business == 1)
        {
            statusBusinessEnvironment.text = "Pass";

            // Đặt màu của text thành 00FF14
            statusBusinessEnvironment.color = new Color32(0, 255, 20, 255);

            statusBusinessEnvironment.gameObject.SetActive(true);
            businessEnvironmentButton.interactable = false;
        }
        else if (ResourceBoost.Instance.business == 2)
        {
            statusBusinessEnvironment.text = "Fail";

            // Đặt màu của text thành FF000B
            statusBusinessEnvironment.color = new Color32(255, 0, 11, 255);

            statusBusinessEnvironment.gameObject.SetActive(true);
            businessEnvironmentButton.interactable = false;
            claimingStatus.text = "You Failed the Test";

            // Đặt màu của text thành FF000B
            claimingStatus.color = new Color32(255, 0, 11, 255);

            claimingStatus.gameObject.SetActive(true);
        }

        if (ResourceBoost.Instance.people == 1 && ResourceBoost.Instance.process == 1 && ResourceBoost.Instance.business == 1) {
            certificateButton.gameObject.SetActive(true);
            peopleButton.interactable = false;
            processButton.interactable = false;
            businessEnvironmentButton.interactable = false;
        }
    }

    public void PeopleTest() {
        SceneManager.LoadScene("People");
    }

    public void ProcessTest()
    {
        SceneManager.LoadScene("Process");
    }

    public void EnvironmentTest()
    {
        SceneManager.LoadScene("Environment");
    }

    public async void ClaimCertificate() {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        claimingStatus.text = "Claiming PMP Certificate...";
        claimingStatus.gameObject.SetActive(true);
        certificateButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract(certificateAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            claimingStatus.text = "Claimed PMP Certificate!";
            claimingStatus.gameObject.SetActive(true);
            certificateButton.gameObject.SetActive(false);
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while claiming the NFT: {ex.Message}");
            // Optionally, update the UI to inform the user of the error
            claimingStatus.text = "Failed to claim Certificate. Please try again.";
            claimingStatus.gameObject.SetActive(true);
            certificateButton.interactable = true;
        }
    }

}
