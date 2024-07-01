This is an example to use system managed identities (from webapp or function) to request a token associated with an authenticated API.
Reference: https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/how-to-assign-app-role-managed-identity?pivots=identity-mi-app-role-cli

The managed identity is treated as user and added as a user in the app registration's Enterprise app

![image](https://github.com/carlosquim/smi-with-roles-example/assets/12561208/390457b5-6520-4c12-8be9-d34dae082eaa)

The app registration has the following roles:
![image](https://github.com/carlosquim/smi-with-roles-example/assets/12561208/fa2f049d-6e87-467e-b00b-150f965a1399)

The token obtained will take the following form: 
![image](https://github.com/carlosquim/smi-with-roles-example/assets/12561208/70e0c0aa-33c7-4ecf-9fd9-ecd1039edfb2)
