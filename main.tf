terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
  }
}

terraform {
    backend "azurerm" {
        resource_group_name  = "tf_rg_blobstorage"
        storage_account_name = "tfolegbabkevichstorage"
        container_name       = "tfstate"
        key                  = "terraform.tfstate"
    }
}

variable "imagebuild" {
  type        = string
  default     = ""
  description = "Latest image build"
}


provider "azurerm" {
    features {}
}

resource "azurerm_resource_group" "tf_test"{
    name = "tfmainrg"
    location = "East US"
}

resource "azurerm_container_group" "tfcg_test"{
    name = "userms"
    location = azurerm_resource_group.tf_test.location
    resource_group_name = azurerm_resource_group.tf_test.name
    ip_address_type = "Public"
    dns_name_label = "olegbabkevichusermicroservice"
    os_type= "Linux"

    container {
    name            = "userms"
    image           = "olegbabkevichcoherentsolutions/usermicroservice:${var.imagebuild}"
    cpu             = "1"
    memory          = "1"

    ports {
        port        = 80
        protocol    = "TCP"
    }
  }
}

