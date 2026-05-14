---
title: Data Solution Automation Schema
description: A generic metadata schema for data solution automation - an exchange format for data logistics generation metadata.
template: splash
hero:
  title: Data Solution Automation Schema
  tagline: A generic exchange format for data solution automation metadata. Decouple metadata from tooling, so any generator can work with any UI.
  actions:
    - text: Getting started
      link: ./overview/getting-started/
      icon: right-arrow
    - text: View on GitHub
      link: https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema
      icon: external
      variant: minimal
---

## Intent

To provide a collaborative space to discuss an exchange format for data logistics ('ETL') generation metadata, supporting Data Solution Automation. The schema captures all metadata required to generate the transformation logic for a Data Warehouse solution.

## Why is this relevant?

Many practitioners have built their own Data Solution automation and code generation solutions, reinventing the wheel each time. Some are built inside existing tools (ERwin, PowerDesigner); others use bespoke frameworks (.NET, Java) and proprietary repositories. Off-the-shelf DSA platforms each have their own formats too.

Rather than competing on which solution is "best," there's room for an interoperable ecosystem where everyone uses the tools and technologies they prefer - as long as the metadata they exchange follows a common interface.

This schema is that interface: an agreement on how source-to-target (mapping) metadata can be captured for use by different tools.

## Hypothesis

Across most metadata models there is a core set of information required to generate ETL. If we can separate this from the UI / management of metadata, we have an exchange format that lets anyone plug in their own technology.

Examples:

- [Agnostic Data Labs](https://agnosticdatalabs.com) implements this schema and provides a dedicated UI and out-of-the-box templates.
- [TEAM](https://github.com/RoelantVos/TEAM) separates UI from SQL generation; the generated mappings are exposed as JSON or database views conforming to the schema.

## Requirements

The fundamental requirements of the metadata adapter are:

- Containing all metadata required to generate ETL output. This notably includes:
  - source-to-target mappings
  - physical model metadata (columns and tables, data types, etc.)
  - connectivity information, or proxy
- Text-based to support version control
