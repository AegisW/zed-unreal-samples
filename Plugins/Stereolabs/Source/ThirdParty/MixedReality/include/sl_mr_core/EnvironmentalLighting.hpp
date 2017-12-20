#pragma once

#include "sl_mr_core/defines.hpp"

namespace sl {
	namespace mr {

		/**
		 * \brief Init the environmental lighting, all the coefficients are initialized during the process.
		 */
		SLMRCORE_API void environmentalLightingInitialize();

		/**
		 * brief Shutdown environmental lighting. No functions can be called after shutdown.
		 */
		SLMRCORE_API void environmentalLightingShutdown();

		/**
		 * \brief Compute the diffuse coefficients
		 * @param buffer The mat buffer storing zed left image
		 */
		SLMRCORE_API void environmentalLightingComputeDiffuseCoefficients(sl::Mat* buffer);

		/**
		 * \brief Return the SHM matrix
		 * @param matrix The SHM matrix
		 * @param index  The column index
		 * @return the SHM matrix
		 */
		SLMRCORE_API void environmentalLightingGetShmMatrix(sl::Matrix4f* matrix, int index);

		/**
		 * \brief Return the exposure
		 * @param deltaTime Delta time of the application
		 * @return The exposure
		 */
		SLMRCORE_API float environmentalLightingGetExposure(float deltaTime);

	}
}

