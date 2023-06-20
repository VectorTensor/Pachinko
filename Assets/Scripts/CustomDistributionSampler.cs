using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class CustomDistributionSampler
{
    private System.Random random;
    private NormalDistribution normalDistribution;

    public CustomDistributionSampler()
    {
        random = new System.Random();
        normalDistribution = new NormalDistribution();
    }

    public double SampleCustomDistribution()
    {
        double x, y;

        do
        {
            // Generate a sample from the proposal distribution (exponential distribution)
            x = GenerateSampleFromProposalDistribution();

            // Generate a uniform random number between 0 and the maximum value of the target distribution
            y = random.NextDouble() * CalculateMaximumTargetDistributionValue();

            // Check if the sample is accepted based on the acceptance criterion
            if (y <= CalculateTargetDistributionValue(x))
                return x;

        } while (true);
    }

    private double GenerateSampleFromProposalDistribution()
    {
        double min = 0.0;
        double max = 1.0;
        return random.NextDouble() * (max - min) + min;

    }

    private double CalculateMaximumTargetDistributionValue()
    {
        // Calculate and return the maximum value of the target distribution
        // This is used for generating the uniform random number y
        // For example, if you know the maximum value of the target distribution, you can return it directly
        return normalDistribution.CalculateProbabilityDensity(0.0);
    }

    private double CalculateTargetDistributionValue(double x)
    {
        // Calculate and return the value of the target distribution at the given x
        // This is used to check if the sample is accepted or rejected
        // Implement your custom distribution function here
        // For example, a normal distribution with mean = 0 and standard deviation = 1:
        double mean = 0.0;
        double standardDeviation = 1.0;
        return normalDistribution.CalculateProbabilityDensity(x, mean, standardDeviation);
    }
}

public class NormalDistribution
{
    public double CalculateProbabilityDensity(double x, double mean = 0.0, double standardDeviation = 1.0)
    {
        double coefficient = 1.0 / (standardDeviation * Math.Sqrt(2 * Math.PI));
        double exponent = -0.5 * Math.Pow((x - mean) / standardDeviation, 2);
        return coefficient * Math.Exp(exponent);
    }
}
