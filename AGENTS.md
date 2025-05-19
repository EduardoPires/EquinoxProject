# AGENTS Setup Guide

This repository requires environment configuration to build and run the .NET 9.0 projects. Run the installation script below with **sudo** or **root** privileges.

## Steps in `setup.sh`

1. Update and upgrade the system:
   ```bash
   apt-get update && apt-get upgrade -y
   ```
2. Install basic dependencies (`wget`, `apt-transport-https`, `ca-certificates`):
   ```bash
   apt-get install -y wget apt-transport-https ca-certificates
   ```
3. Add the Microsoft package key and update package lists:
   ```bash
   wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb
   dpkg -i packages-microsoft-prod.deb
   apt-get update
   ```
4. Install **.NET SDK 9.0**:
   ```bash
   apt-get install -y dotnet-sdk-9.0
   ```
   Verify the installation:
   ```bash
   dotnet --version
   ```
5. (Optional) Remove old packages:
   ```bash
   apt-get autoremove -y
   ```

## Notes from the README

- Use the latest version of **Visual Studio** or **Visual Studio Code**.
- Ensure the matching runtime version of the SDK is installed as indicated by the project.
- You can also run the Equinox Project in Visual Studio Code on Windows, Linux or macOS.
