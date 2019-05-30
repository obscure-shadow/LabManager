# LabManager

Every laboratory should be able to track its inventory easily and efficiently. Yet, many labs still use hand-written logs or Excel workbooks because of the cost that an inventory system (or addition to their current LIMS) would incur. LabManager was created to help laboratories track the details of their inventory in a convenient and efficient manner without dramatically increasing overhead costs due to software expenses. 


## Technologies Used

This project was built in C# using Microsoft Asp.Net Core (v2.2) with Entity Framework and Identity for user authentication. Data was managed and organized via Microsoft SQL Server (v17). Visual Studio


## Getting Started

(coming soon)

### Login

You will first be presented with a login screen requiring your credentials. 
If you do not have an account, you must first register. 

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerLoginRegister.png)


You may also login with the following sample credentials:

Username: `labmanager@email.com"`
Password: `LabManager1!`


### Viewing Your Dashboard

Upon successful authentication, you will be redirected to your dashboard. From here, you may choose Chemicals or Lab Items by clicking on the image of one of them. 

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerDash.png)


### Chemicals

When choosing Chemicals, you will be redirected to the Chemicals display. This will be a table consisting of all chemicals in the database. 

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerChemicalsListBefore.png)


If you wish to see which chemicals are expiring soon or when the most recent chemicals were received, you may use the up and down arrows on a given column to sort chemicals according to your preferred view. Chemicals are sorted by most-recently-added by default.


#### Creating a Chemical

To add a new chemical to the list, choose "Add New Chemical". You will be presented with a form for creating a new chemical. 

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerChemicalsListCreate.png)


Enter the details of the chemical you wish to create (dropdown menus contain most common chemical types, manufacturers, and the employees registered in LabManager). Enter details about the chemical you find relevant (for instance, if the item was received without a proper seal or too warm or broken, use the `Notes` field to enter this information) The `COA` field should contain a hyperlink to the certificate of analysis for the chemical from the manufacturer's website. When you are finished entering information, click `Create` and you will be redirected back to the Chemicals list view where you will be able to see the chemical you just added.

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerChemicalsList.png)

#### Editing a Chemical

If a user wishes to edit a chemical (for instance, if the chemical has just been opened), the user may choose the Chemical from the list by clicking on the "edit" icon on the right-hand side of the table. This will redirect the user to a pre-populated edit form for the selected chemical. Enter the information you wish to edit and click the `Save` button. This will redirect you back to the chemicals list page and you will be able to see your edited item.

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerChemicalsEditAndList.png)

#### Viewing the Details of a Chemical

Not all details about a particular chemical are visible from the chemicals list screen. Details such as Notes and COA are not necessarily relevant to a user simply looking for quick information such as a name or expiration date, however, other details may be viewed by selecting the "information" icon on the right-hand side of the table for a given chemical.

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerChemicalsDetailsAndList.png)


#### Deleting a Chemical

If a given chemical should be removed from the inventory, it can be deleted by choosing the trash can icon on the right-hand side of the chemical of interest from the chemicals list. The user will be prompted to confirm their desire to delete the chemical. They may return to the chemicals list without deleting the item or they may proceed with deletion. 

![](/LabManager/wwwroot/images/ReadmeImages/LabManagerChemicalsDeleteList.png)



### Lab Items

#### Creating a Lab Item


#### Editing a Lab Item


#### Viewing the Details of a Lab Item


#### Deleting a Lab Item



### Nashville Software School Back-End Capstone
### &copy; Hannah Neal 2019
