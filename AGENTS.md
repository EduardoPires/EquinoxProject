# AGENTS Setup Guide

This repository requires specific environment configuration to build and run .NET 9.0 projects. **All dependencies must be installed during the setup script phase,** especially in restricted environments (e.g., OpenAI Codex).

## Setup Steps (`setup.sh`)

1. **Update and upgrade the system:**
    
    `apt-get update && apt-get upgrade -y`
    
2. **Install essential dependencies (`wget`, `apt-transport-https`, `ca-certificates`):**
    
    `apt-get install -y wget apt-transport-https ca-certificates`
    
3. **Configure Microsoft package source and update package lists:**
    
    `wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb`
    
    `dpkg -i packages-microsoft-prod.deb`
    
    `rm packages-microsoft-prod.deb`
    
    `apt-get update`
    
4. **Install .NET SDK 9.0:**
    
    `apt-get install -y dotnet-sdk-9.0`
    
5. **Verify installation:**
    
    `dotnet --version`
    
6. **(Optional) Remove obsolete packages:**
    
    `apt-get autoremove -y`
    

---

## ⚠️ Notes for Codex and Similar Cloud Environments

- **Internet access is only available during the setup script phase.** All dependencies must be installed in this initial script.
- **A network proxy is always active:** Standard environment variables like `http_proxy`, `https_proxy`, and the proxy certificate (`$CODEX_PROXY_CERT`) are automatically set. These should be respected by all package managers and CLI tools.
- **If you encounter connectivity issues:**
    - Ensure your setup script is running during the setup/initialization phase (not in the regular terminal).
    - Check that all required dependencies are installed up front.
    - Make sure environment variables for the proxy/certificate are being used by your tools.

---

## General Recommendations

- Use the latest version of **Visual Studio** or **Visual Studio Code** for development.
- Always install the correct SDK and runtime versions as required by this project.
- The project can be built and run in Visual Studio Code on Windows, Linux, or macOS.

---

**IMPORTANT:**

If using a cloud development platform or automated environment, ensure all tools and dependencies are installed during the setup script phase. No additional internet access will be available after environment initialization. Plan accordingly.
