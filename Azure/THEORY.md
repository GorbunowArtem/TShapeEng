## Azure Blob vs Files - key difference, use cases.
- Azure Blob Storage is an object store used for storing vast amounts unstructured data
  is much cheaper  
  -- You want your application to support streaming and random access scenarios.
  -- You want to be able to access application data from anywhere.
  -- You want to build an enterprise data lake on Azure and perform big data analytics.
-  Azure File Storage is a fully managed distributed file system based on the SMB(Server Message Block ) protocol and looks like a typical hard drive once mounted. 
   Targeted more to internal file handling. With internal I mean mounting a directory to a VM in the cloud or on-premises so it can be loaded in you back-end (SMB based protocol).
    -- You want to "lift and shift" an application to the cloud that already uses the native file system APIs to share data between it and other applications running in Azure.
    -- You want to replace or supplement on-premises file servers or NAS devices
    -- You want to store development and debugging tools that need to be accessed from many virtual machines.    

## Cool/hot/archive blob tiers - key difference, use cases.
         
- cool
  -- Optimized for storing data that is infrequently accessed and stored for at least 30 days.
  The cool access tier has lower storage costs and higher access costs compared to hot storage.
  This tier is intended for data that will remain in the cool tier for at least 30 days.
  Example usage scenarios for the cool access tier include:

Short-term backup and disaster recovery
Older data not used frequently but expected to be available immediately when accessed
Large data sets that need to be stored cost effectively, while more data is being gathered for future processing
- hot 
  -- Optimized for storing data that is accessed frequently.
  The hot access tier has higher storage costs than cool and archive tiers, but the lowest access costs.
  Example usage scenarios for the hot access tier include:

Data that's in active use or is expected to be read from and written to frequently
Data that's staged for processing and eventual migration to the cool access tier
  
- archive
    -- Optimized for storing data that is rarely accessed and stored for at least 180 days with flexible latency requirements, on the order of hours.
  The archive access tier has the lowest storage cost but higher data retrieval costs compared to hot and cool tiers. Data must remain in the archive tier for at least 180 days or be subject to an early deletion charge. Data in the archive tier can take several hours to retrieve depending on the specified rehydration priority. For small objects, a high priority rehydrate may retrieve the object from archive in under an hour. See Rehydrate blob data from the archive tier to learn more.

While a blob is in archive storage, the blob data is offline and can't be read or modified.
To read or download a blob in archive, you must first rehydrate it to an online tier.
You can't take snapshots of a blob in archive storage. However, the blob metadata remains online and available, allowing you to list the blob, its properties, metadata, and blob index tags. Setting or modifying the blob metadata while in archive isn't allowed. However, you can set and modify the blob index tags. For blobs in archive, the only valid operations are Get Blob Properties, Get Blob Metadata, Set Blob Tags, Get Blob Tags, Find Blobs by Tags, List Blobs, Set Blob Tier, Copy Blob, and Delete Blob.

Example usage scenarios for the archive access tier include:

Long-term backup, secondary backup, and archival datasets
Original (raw) data that must be preserved, even after it has been processed into final usable form
Compliance and archival data that needs to be stored for a long time and is hardly ever accessed


Data stored in the cloud grows at an exponential pace.
To manage costs for your expanding storage needs, it's helpful to organize your data based on attributes like frequency-of-access
and planned retention period to optimize costs.
Data stored in the cloud can be different based on how it's generated, processed, and accessed over its lifetime.
Some data is actively accessed and modified throughout its lifetime.
Some data is accessed frequently early in its lifetime, with access dropping drastically as the data ages.
Some data remains idle in the cloud and is rarely, if ever, accessed after it's stored.

## Page/block/append blobs -key difference, use cases.
- Block blobs store text and binary data. Block blobs are made up of blocks of data that can be managed individually. Block blobs can store up to about 190.7 TiB.
- Append blobs are made up of blocks like block blobs, but are optimized for append operations. Append blobs are ideal for scenarios such as logging data from virtual machines.
- Page blobs store random access files up to 8 TiB in size. Page blobs store virtual hard drive (VHD) files and serve as disks for Azure virtual machines.


## Let's say we want to use Azure Blob for hosting assets for SPA. Is it possible? What are specifics/limitations/drawbacks?
- anonymous access
- case-sensitive
- $web
- Use CDN and PoP
         
## IaaS/Containers/PaaS/Serverless - please name Azure compute services, implementing each approach. Compare them - difference/benefits/drawbacks/use cases?
    - IaaS
Storage accounts, Virtual desktop, virtual machines
  - PaaS 
App Services, Azure Search and Azure CDN, CosmosDb, Azure SQL
    - SaaS
Azure IoT Suite and Office 365.

## How do you understand serverless approach? What are the "serverless" applications in fact?
- Function as a service

- Drawbacks:
  -- cold start
  -- ram limitations
  -- manage

                           
