---
title: DataConnection
description: 'Connectivity information, that can be used for either a DataObject or DataObjectQuery. This is be a key, token, reference, connection string and similar.'
---

Connectivity information, that can be used for either a DataObject or DataObjectQuery. This is be a key, token, reference, connection string and similar.

> **Source of truth:** [DataConnection.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataConnection.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | Optional identifier as a string value to allow various identifier approaches. |
| `name` | `string` | The connection information expressed in a key, token or (connection)string. |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the Data Item for use in generation logic (evaluation). |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `templateMappings` | `array of TemplateMapping` | The collection of template references that apply to this Data Connection. |
| `notes` | `string` | Free-format notes. |

