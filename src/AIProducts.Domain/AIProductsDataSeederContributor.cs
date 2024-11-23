using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIProducts.ProductCategories;
using AIProducts.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AIProducts;

public class AIProductsDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<ProductCategory, int> _productCategoryRepository;
    private readonly IRepository<Product, int> _productRepository;

    public AIProductsDataSeederContributor(
        IRepository<ProductCategory, int> productCategoryRepository,
        IRepository<Product, int> productRepository)
    {
        _productCategoryRepository = productCategoryRepository;
        _productRepository = productRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        Dictionary<int, ProductCategory> productCategories = [];

        if (await _productCategoryRepository.GetCountAsync() <= 0)
        {
            productCategories[1] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "AI Software",
                    Description = "Software solutions with integrated AI capabilities",
                    Icon = "ai_software_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[2] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "Autonomous Drones",
                    Description = "Unmanned aerial vehicles with advanced AI navigation systems",
                    Icon = "autonomous_drones_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[3] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "AI Personal Assistants",
                    Description = "Virtual assistants powered by artificial intelligence for personal use",
                    Icon = "ai_personal_assistants_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[4] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "Smart Home Devices",
                    Description = "Home appliances and systems with AI for automation and control",
                    Icon = "smart_home_devices_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[5] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "AI Security Systems",
                    Description = "Advanced security systems using AI for threat detection and response",
                    Icon = "ai_security_systems_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[6] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "Healthcare AI",
                    Description = "AI applications for diagnostics, treatment planning, and patient management",
                    Icon = "healthcare_ai_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[7] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "AI Education Platforms",
                    Description = "Educational platforms utilizing AI for personalized learning experiences",
                    Icon = "ai_education_platforms_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
            productCategories[8] = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "AI Financial Tools",
                    Description = "Financial tools and apps enhanced with AI for better decision making",
                    Icon = "ai_financial_tools_icon.png",
                    TaxRate = "0.01%",
                    Notes = "",
                },
                autoSave: true
            );
        }

        Dictionary<int, Product> products = [];

        if (await _productRepository.GetCountAsync() <= 0)
        {
            products[101] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Quantum AI Processor",
                    Description = "A next-generation processor for advanced AI computations",
                    Price = 2499.99,
                    StockQuantity = 50,
                    Photo = "quantum_ai_processor.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[102] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "SkyNet Drone",
                    Description = "A high-endurance drone with real-time AI analytics capabilities",
                    Price = 4999.99,
                    StockQuantity = 20,
                    Photo = "skynet_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[103] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Home AI Butler",
                    Description = "An AI-powered device that manages your smart home ecosystem",
                    Price = 799.99,
                    StockQuantity = 100,
                    Photo = "home_ai_butler.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[104] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Chipset Max",
                    Description = "Advanced chipset designed for deep learning operations",
                    Price = 1299.99,
                    StockQuantity = 75,
                    Photo = "ai_chipset_max.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[105] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Eagle Eye Drone",
                    Description = "Drone with enhanced vision AI for precision surveillance",
                    Price = 3500,
                    StockQuantity = 30,
                    Photo = "eagle_eye_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[106] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Coffee Maker",
                    Description = "Smart coffee maker with personalized AI taste calibration",
                    Price = 299.99,
                    StockQuantity = 200,
                    Photo = "ai_coffee_maker.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[107] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Neural Net Core",
                    Description = "Processor that mimics human brain neural networks",
                    Price = 3199.99,
                    StockQuantity = 40,
                    Photo = "neural_net_core.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[108] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Aqua Scout Drone",
                    Description = "Water-resistant drone with AI for marine research",
                    Price = 2800,
                    StockQuantity = 15,
                    Photo = "aqua_scout_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[109] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Fitness Coach",
                    Description = "Wearable device with AI for personalized fitness coaching",
                    Price = 499.99,
                    StockQuantity = 150,
                    Photo = "ai_fitness_coach.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[110] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Quantum Data Server",
                    Description = "High-speed server optimized for quantum AI calculations",
                    Price = 10000,
                    StockQuantity = 10,
                    Photo = "quantum_data_server.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[111] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Strato Climber Drone",
                    Description = "High-altitude drone with AI for atmospheric studies",
                    Price = 4200,
                    StockQuantity = 25,
                    Photo = "strato_climber_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[112] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Smart Lock",
                    Description = "Home security lock with facial recognition AI technology",
                    Price = 249.99,
                    StockQuantity = 300,
                    Photo = "ai_smart_lock.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[113] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Dev Kit",
                    Description = "Development kit with AI modules for tech enthusiasts",
                    Price = 599.99,
                    StockQuantity = 120,
                    Photo = "ai_dev_kit.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[114] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Night Hawk Drone",
                    Description = "Stealth drone with AI for nocturnal monitoring",
                    Price = 3800,
                    StockQuantity = 18,
                    Photo = "night_hawk_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[115] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Pet Companion",
                    Description = "AI device that interacts and cares for your pets",
                    Price = 349.99,
                    StockQuantity = 80,
                    Photo = "ai_pet_companion.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[116] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Supercomputer",
                    Description = "Supercomputer with AI for complex problem solving",
                    Price = 15000,
                    StockQuantity = 5,
                    Photo = "ai_supercomputer.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[117] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Recon Scout Drone",
                    Description = "Compact drone with AI for tactical reconnaissance",
                    Price = 3100,
                    StockQuantity = 22,
                    Photo = "recon_scout_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[118] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Thermostat",
                    Description = "Intelligent thermostat with AI for energy optimization",
                    Price = 199.99,
                    StockQuantity = 250,
                    Photo = "ai_thermostat.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[119] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Crypto Miner",
                    Description = "Dedicated AI system for efficient cryptocurrency mining",
                    Price = 4500,
                    StockQuantity = 60,
                    Photo = "ai_crypto_miner.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[120] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Forest Ranger Drone",
                    Description = "AI drone for monitoring wildlife and forest health",
                    Price = 3600,
                    StockQuantity = 28,
                    Photo = "forest_ranger_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
            products[121] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Language Tutor",
                    Description = "AI-powered device for learning new languages",
                    Price = 399.99,
                    StockQuantity = 90,
                    Photo = "ai_language_tutor.jpg",
                    Notes = "",
                    ProductCategory = productCategories[3],
                },
                autoSave: true
            );
            products[122] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "AI Genome Analyzer",
                    Description = "AI system for rapid genome sequencing and analysis",
                    Price = 7500,
                    StockQuantity = 35,
                    Photo = "ai_genome_analyzer.jpg",
                    Notes = "",
                    ProductCategory = productCategories[1],
                },
                autoSave: true
            );
            products[123] = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Urban Explorer Drone",
                    Description = "Drone with AI for urban mapping and exploration",
                    Price = 3300,
                    StockQuantity = 12,
                    Photo = "urban_explorer_drone.jpg",
                    Notes = "",
                    ProductCategory = productCategories[2],
                },
                autoSave: true
            );
        }
    }
}
